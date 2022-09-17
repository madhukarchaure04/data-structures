class TrieNode
    {
        private Dictionary<char, TrieNode> children;
        private char wordEnd = '*';
        public TrieNode()
        {
            children = new Dictionary<char, TrieNode>();
        }
        
        public bool DoesNotContainsChild(char c) => !children.ContainsKey(c);
        
        public void AddChild(char c) => children[c] = new TrieNode();
        
        public TrieNode GetChild(char c) => children[c];

        public void AddWordEnd() => children[wordEnd] = null;

        public bool ContainsWordEnd() => children.ContainsKey(wordEnd);
    }
    
    class Trie
    {
        TrieNode root;
        public Trie()
        {
            root = new TrieNode();
        }
        
        public void AddWord(string word)
        {
            TrieNode node = root;
            foreach(char c in word)
            {
                if(node.DoesNotContainsChild(c))
                {
                    node.AddChild(c);
                }
                node = node.GetChild(c);
            }
            node.AddWordEnd();
        }
        
        public bool FindWord(string word)
        {
            TrieNode node = root;
            foreach(char c in word)
            {
                if(node.DoesNotContainsChild(c))
                {
                    return false;
                }
                node = node.GetChild(c);
            }
            return node.ContainsWordEnd();
        }
    }

    /*
    //Using the trie

    //Create instance
    Trie trie = new Trie();

    //Add words to trie
    trie.AddWord("Hello");
    trie.AddWord("world");
    
    //Find the word
    trie.FindWord("world"); -> Returns true;
    trie.FindWord("new"); -> Returns false;
    */