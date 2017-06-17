using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DuplicateMonitor
{
    partial class FileHashStore

    {
        private HashHolder fhh = new HashHolder(0,' ');
        private Dictionary<string, string> dictFiles = new Dictionary<string, string>();

       public string ExamineFile (string strHash, string strFilePath)
        {
            HashSet<string> hsTemp;
            hsTemp = fhh.GetFileList(strHash);

            if (dictFiles.ContainsKey(strFilePath))
            {
                if (dictFiles[strFilePath] == strHash)
                {
                    return "No Change";
                }
                else
                {
                    fhh.GetFileList(dictFiles[strFilePath]).Remove(strFilePath);
                    fhh.AddFilePath(strHash, strFilePath);
                    dictFiles[strFilePath] = strHash;
                    return "File Contents Changed - Updated Stored Hash";
                }
            }
            else if (hsTemp != null)
            {
                hsTemp.Add(strFilePath);
                dictFiles.Add(strFilePath, strHash);
                return "Duplicate Files" + String.Join("/", hsTemp.Select(x => x));
            }
            else
            {
                fhh.AddFilePath(strHash, strFilePath);
                dictFiles.Add(strFilePath, strHash);
                return "Unique, hash added.";
            }
            
        }
    }


}
