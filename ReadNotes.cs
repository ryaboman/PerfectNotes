using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonCL;
using System.IO;

namespace RMPerfectNotes{
    class ReadNotes {
        //Читаем текстовый файл
        //
        Txt txt = new Txt();

        string path = Path.Combine(Directory.GetCurrentDirectory(), "composition");

        public Dictionary<string, List<Note>> Reader()
        {
            if (txt.SetPathToFile(path))
            {
                string keys = txt.Select("<Keys>", "</Keys>");                

                Txt selector = new Txt();

                selector.text = keys;            
                List<string> listKeys = selector.SelectMiddleText("<_", "_>");

                Dictionary<string, List<Note>> dictionary = new Dictionary<string, List<Note>>();

                foreach (var key in listKeys)
                {
                    string beginBlock = "<" + key + ">";
                    string endBlock = "</" + key + ">";

                    selector.text = txt.Select(beginBlock, endBlock);
                    List<string> subblockes = selector.SelectBlock("<note>", "</note>");

                    List<Note> notes = new List<Note>();
                    //Для каждой клавиши фортепиано, прочитаем все ноты
                    foreach (var subblock in subblockes)
                    {
                        selector.text = subblock;                         

                        try
                        {
                            Note note = new Note();

                            note.pitchName = key;
                            note.forceDown = Int32.Parse(selector.Select("<force>", "</force>"));
                            note.startTime = float.Parse(selector.Select("<startTime>", "</startTime>"));
                            note.endTime = float.Parse(selector.Select("<endTime>", "</endTime>"));

                            notes.Add(note);
                        }
                        catch
                        {

                        }

                        
                    }

                    dictionary[key] = notes;
                }

                return dictionary;

            }

            return null;
        }
    }

    class WriteNotes
    {
        Txt txt = new Txt();

        string path = Path.Combine(Directory.GetCurrentDirectory(), "composition");

        public void Write(Dictionary<string, List<Note>> dictionary)
        {
            string keys = string.Empty;

            string megaBlock = string.Empty;

            if (txt.SetPathToFile(path))
            {                
                foreach(var dict in dictionary)
                {
                    string block = string.Empty;

                    string beginBlock = "<" + dict.Key + ">";
                    string endBlock = "</" + dict.Key + ">";

                    block += beginBlock + "\n\n";

                    keys += "<_" + dict.Key + "_>, ";

                    

                    foreach (var note in dict.Value)
                    {
                        string subblock = string.Empty;
                        string beginSubblock = "<note>";
                        string endSubblock = "</note>";

                        string force = "<force>" + note.forceDown + "</force>";
                        string startTime = "<startTime>" + note.startTime + "</startTime>";
                        string endTime = "<endTime>" + note.endTime + "</endTime>";

                        string middleText = force + "\n" + startTime + "\n" + endTime;

                        subblock = beginSubblock + "\n" + middleText + "\n" + endSubblock;


                        block += subblock + "\n\n";
                    }

                    block += endBlock + "\n\n";
                    megaBlock += block;

                }

                txt.text = "<Keys>" + keys + "</Keys>" + "\n\n" + megaBlock;
                txt.RewriteFile();
                //txt.WriteBlock();

            }
        }
    }
}
