using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using RMControls.ViewNotes;
using Midi;

//Основано на статье https://habr.com/ru/articles/149075/

namespace RMPerfectNotes {
    public partial class PerfectNotes : Form{
        float timeStartComposition = -1;        

        private Dictionary<Pitch, float> events;
        InputDevice device;

        //флаг педали (true - нажата, false - отпущена) 
        bool sustain = false;

        Dictionary<string, List<Note>> composition = null;
        //List<Note> listNotes = Li

        //Инициализация формы
        public PerfectNotes() {            
            InitializeComponent();
            LoadMidiDevices();

            events = new Dictionary<Pitch, float>();

            composition = new Dictionary<string, List<Note>>();
        }

        //Загружаем все подключенные устройства
        private void LoadMidiDevices(){
            foreach (InputDevice d in InputDevice.InstalledDevices){
                DeviceList.Items.Add(d.Name);
            }

            if (DeviceList.Items.Count > 0)
                DeviceList.SelectedIndex = 0;

            

            
            //UpdateDevice();
        }

        //подключаемся к устройству
        private void UpdateDevice(){
            if (device != null){
                if (device.IsReceiving)
                    device.StopReceiving();
                if (device.IsOpen)
                    device.Close();
            }

            device = InputDevice.InstalledDevices[DeviceList.SelectedIndex];
            if (!device.IsOpen)
                device.Open();

            if (device.IsReceiving)
                device.StopReceiving();

            device.StartReceiving(null);

            if (device != null){
                device.NoteOn += new InputDevice.NoteOnHandler(this.NoteOn);
                device.NoteOff += new InputDevice.NoteOffHandler(this.NoteOff);
                device.ControlChange += new InputDevice.ControlChangeHandler(this.ControlChange);                
            }
        }

        //Если изменили устройсво в выпадающем меню, то необходимо подключиться
        private void DeviceList_SelectedIndexChanged(object sender, EventArgs e){
            UpdateDevice();
        }

        //------------------------------------------------------------------------------------

        //обработчик события "Нажатие клавиши"
        public void NoteOn(NoteOnMessage msg){   
            
            if(timeStartComposition == -1)
            {
                timeStartComposition = msg.Time;
            }
            //MessageBox.Show("клавиша Нажата ");
            //MessageBox.Show(msg.Pitch.PositionInOctave().ToString());
            //MessageBox.Show(msg..ToString());
            lock (this)
            {
                Note note = new Note();
                //msg.Pitch. + msg.Pitch.Octave().ToString();
                note.pitchName = msg.Pitch.ToString();
                note.startTime = msg.Time - timeStartComposition;
                note.forceDown = msg.Velocity;
                //Создается, что-то вроде события, чтобы определить длительность нажатия клавиши
                events[msg.Pitch] = msg.Time;

                if (!composition.ContainsKey(note.pitchName))
                    composition[note.pitchName] = new List<Note>();

                composition[note.pitchName].Add(note);

            }
        }

        //обработчик события "Отпускание клавиши"
        public void NoteOff(NoteOffMessage msg){
            lock (this) {              
                if (events.ContainsKey(msg.Pitch))
                {
                    Note note = composition[msg.Pitch.ToString()].Last();

                    note.endTime = msg.Time - timeStartComposition;
                    note.forceUp = msg.Velocity;

                    events.Remove(msg.Pitch);                   
                }
            }
        }

        //обработчик события "Нажатие педали"
        public void ControlChange(ControlChangeMessage msg) {
                     
            if (msg.Control == Midi.Control.SustainPedal) {
                //Запуск "Композиции"
                if (timeStartComposition == -1)
                {
                    timeStartComposition = msg.Time;
                }

                if ((msg.Value > 64) && !sustain)
                {
                    Note note = new Note();
                    //msg.Pitch. + msg.Pitch.Octave().ToString();
                    note.pitchName = "Pedal#";
                    note.startTime = msg.Time - timeStartComposition;                    

                    if (!composition.ContainsKey(note.pitchName))
                        composition[note.pitchName] = new List<Note>();

                    composition[note.pitchName].Add(note);

                    sustain = true;

                }
                if ((msg.Value < 64) && sustain)
                {
                    Note note = composition["Pedal#"].Last();
                    note.endTime = msg.Time - timeStartComposition;
                  
                    sustain = false;

                }
            }
            return;
        }

        //------------------------------------------------------------------------------------

        //Закрываем форму и отключаемся от устройства
        private void SettingsWindow_FormClosing(object sender, FormClosingEventArgs e) {
            if(device != null){
                device.StopReceiving();
                device.Close();
            }
            
        }

        void Fide(float StartBlockTime, float EndBlockTime, List<Note> notes){
            List<Note> listNotes = new List<Note>();
            foreach(var note in notes){
                if ((StartBlockTime < note.startTime && EndBlockTime > note.startTime) ||
                     (StartBlockTime < note.endTime && EndBlockTime > note.endTime) ||
                     StartBlockTime > note.startTime && EndBlockTime < note.endTime){
                    listNotes.Add(note);
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e){
            ViewerNote.Change(20, 0);
        }

        private void button2_Click(object sender, EventArgs e){
            ViewerNote.Change(-20, 0);
        }

        private void ShowComposition_Click(object sender, EventArgs e){
            if(composition.Count == 0)
                composition = new ReadNotes().Reader();

            ViewerNote.CreateBorders(castNoteToINotable(composition));
        }

        private Dictionary<string, List<INotable>> castNoteToINotable(Dictionary<string, List<Note>> notes_dic) {
            Dictionary<string, List<INotable>> inotes_dic = new Dictionary<string, List<INotable>>();
            foreach (var keyValuePair in notes_dic) {
                List<INotable> notables = new List<INotable>();
                foreach (var note in keyValuePair.Value) {
                    notables.Add(note);
                }
                inotes_dic.Add(keyValuePair.Key, notables);
            }
            return inotes_dic;
        }

        private void BtnWriteComposition_Click(object sender, EventArgs e){
            if(composition.Count > 0){
                WriteNotes writter = new WriteNotes();
                writter.Write(composition);
            }            
        }

        private void BtnCleat_Click(object sender, EventArgs e){
            timeStartComposition = -1;
            composition.Clear();
        }
    }
}
