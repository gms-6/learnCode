using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learncode.Model
{
    public class WordDictionary
    {
        private Trie root;
        public WordDictionary()
        {
            root = new Trie();
        }
        public void addWord(string word)
        {
            root.Insert(word);
        }
        public bool Search(string word)
        {
            return DFS(word,0,root);
        }
        private bool DFS(string word,int index,Trie node)
        {
            if (index == word.Length)
                return node.GetIsEnd();
            char ch = word[index];
            if(ch!='.')
            {
                int childIndex = ch - 'a';
                Trie child = node.GetChildren()[childIndex];
                if (child != null && DFS(word, index + 1, child))
                    return true;
            }
            else
            {
                for(int i=0;i<26;++i)
                {
                    Trie child = node.GetChildren()[i];
                    if (child != null && DFS(word, index + 1, child))
                        return true;
                }
            }
            return false;
        }
    }
}
