using System.Collections.Generic;

namespace DuplicateMonitor
{
    partial class FileHashStore
    {
        class HashHolder
        {
            int intLevel;
            char chrNode;

            Dictionary<char, HashHolder> hhMore = new Dictionary<char, HashHolder>();
            //Only used at end root.
            HashSet<string> FilePaths;

            public HashHolder(int intLevelSet, char chrSet)
            {
                if (intLevelSet == 32)
                {
                    FilePaths = new HashSet<string>();
                }
                intLevel = intLevelSet;
                chrNode = chrSet;
            }

            public void AddFilePath(string strHashPart, string strFilePath)
            {
                if (intLevel < 32)
                {
                    char charTemp = strHashPart[0];
                    if (hhMore.ContainsKey(charTemp) == false) 
                    {
                        hhMore.Add(charTemp, new HashHolder(intLevel + 1, charTemp));
                    }
                    hhMore[charTemp].AddFilePath(strHashPart.Substring(1, strHashPart.Length - 1), strFilePath);
                }
                else
                {
                    FilePaths.Add(strFilePath);
                }
            }

            public HashSet<string> GetFileList(string strHashPart)
            {
                if (intLevel < 32)
                {
                    char charTemp = strHashPart[0];
                    if (hhMore.ContainsKey(charTemp) == false)
                    {
                        return null;
                    }
                    else
                    {
                        return hhMore[charTemp].GetFileList(strHashPart.Substring(1, strHashPart.Length - 1));
                    }
                }
                else
                {
                    return FilePaths;
                }
            }

         
        }
    }
}
