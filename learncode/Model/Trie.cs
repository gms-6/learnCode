using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learncode.Model
{
    public  class Trie
    {
        private Trie[] children;
        private bool isEnd;
        public Trie()
        {
            children = new Trie[26];
            isEnd = false;
        }

        public void Insert(string word)
        {
            Trie node = this;
            for(int i=0;i<word.Length;++i)
            {
                char ch = word[i];
                int index = ch - 'a';
                if(node.children[index]==null)
                {
                    node.children[index] = new Trie();
                }
                node = node.children[index];
            }
            node.isEnd = true;
        }

        public bool Search(string word)
        {
            Trie node = searchPrefix(word);
            return node != null && node.isEnd;
        }

        public bool StartsWith(string prefix)
        {
            return searchPrefix(prefix) != null;
        }
        private Trie searchPrefix(string prefix)
        {
            Trie node = this; 
            for(int i=0;i<prefix.Length;++i)
            {
                char ch = prefix[i];
                int index = ch - 'a';
                if (node.children[index] == null)
                    return null;
                node = node.children[index];
            }
            return node;
        }
        public Trie[] GetChildren()
        {
            return children;
        }
        public bool GetIsEnd()
        {
            return isEnd;
        }
    }
}
