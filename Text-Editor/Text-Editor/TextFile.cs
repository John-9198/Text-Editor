using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Editor
{
    /// <summary>Class that contains info about the text file</summary>
    public class TextFile
    {
        /// <summary>Path to the file (with file name and extension)</summary>
        private string m_path;

        /// <summary>Text in the file</summary>
        private string m_text;

        private bool m_is_saved;

        /// <summary>Creates empty class object</summary>
        public TextFile() { }

        /// <summary>Creates class object and opens the file for transferred path</summary>
        public TextFile(string path) : this()
        {
            Open(path);
        }

        public bool IsSaved
        {
            get
            {
                return m_is_saved;
            }
        }

        /// <summary>Returns the path to the file (with file name and extension)</summary>
        /// <returns>Path to the file (with file name and extension)</returns>
        public string GetPath()
        {
            return m_path;
        }

        /// <summary>Sets the path to the file (with file name and extension)</summary>
        /// <param name="new_path">New path to the file (with file name and extension)</param>
        public void SetPath(string new_path)
        {
            m_path = new_path;
        }

        /// <summary>Returns the text of the file</summary>
        /// <returns>Path text of the file</returns>
        public string GetText()
        {
            return m_text;
        }

        /// <summary>Sets the text of the file</summary>
        /// <param name="new_text">New text of the file</param>
        public void SetText(string new_text)
        {
            if (new_text != m_text)
            {
                m_text = new_text;
                m_is_saved = false;
            }
        }

        /// <summary>Opens the file for transferred path</summary>
        /// <param name="path">Path to the file (with file name and extension)</param>
        public void Open(string path)
        {
            m_path = path;
            m_text = System.IO.File.ReadAllText(m_path);
            m_is_saved = true;
        }

        /// <summary>Saves text in the file</summary>
        public void Save()
        {
            System.IO.File.WriteAllText(m_path, m_text);
            m_is_saved = true;
        }
    }
}
