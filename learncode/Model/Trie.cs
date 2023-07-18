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


        //        主要职责有 负责管理调度仓储物流信息系统的作业队列，对外API交互接口的开发与维护，设备的软件自动化调度，数据库的开发和维护等工作，在工作中我一直保持了极大的热情，积极地学习技术和业务知识，不断地丰富和拓展自己的知识深度和广度,为公司创造更多的价值。我的技术栈为熟悉C#，多线程相关知识，了解C++语法与面向对象知识，能够使用C#面向对象，.net搭建出后端框架、熟悉mysql数据库，掌握sql语句的编写、熟练掌握数据结构与算法，掌握常见设计模式，策略模式、单例模式、观察者模式，工厂模式、简单工厂模式。
        //在生活中，我的兴趣爱好是健身和篮球，性格开朗，做事认真踏实，



//        我叫郭明顺，今年24岁，2022年6月本科毕业于211江南大学自动化专业。我对软件开发充满了热情，并且在大学期间专注于学习和实践相关知识。

//毕业后，我加入了无锡中科微至科技股份有限公司的智能仓储软件部，担任C#开发工程师的职位。我在这个岗位上负责开发WCS（仓库控制系统）软件，其中的工作内容包括管理和调度仓储物流信息系统的作业队列，开发和维护对外API交互接口，进行设备的软件自动化调度，以及数据库的开发和维护等工作。

//在工作中，我始终保持着极大的热情和积极的学习态度。我不断地深化和拓展自己的技术和业务知识，以为公司创造更多的价值。我的技术栈主要集中在C#方面，熟悉多线程相关知识，并了解C++语法和面向对象知识。我能够使用C#来构建后端框架，并熟悉使用.NET平台。此外，我熟悉MySQL数据库，能够编写SQL语句进行数据库操作。我还掌握了数据结构与算法的基本知识，并熟悉常见的设计模式，如策略模式、单例模式、观察者模式、工厂模式和简单工厂模式。

//除了工作上的兴趣和专注，我在生活中也注重身心健康。我喜欢健身和打篮球，这些爱好使我保持积极开朗的性格，并且在工作中认真踏实地对待每一项任务。
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
