using System;
using System.Collections.Generic;
using System.Text;

namespace Lab01.Bridge
{

    class Lab1 : ILab
    {
        private int _difficility;
        public int Difficility { get { return _difficility; } set { _difficility = value; } }
        private List<String> _paterns;
        public List<String> Paterns { get {return _paterns; } set { _paterns = value;} }
        private int _id;
        public int Id { get {return _id; } set { _id = value;} }
        public Lab1(int Difficility, List<String> Paterns, int Id, string FabricName)
        {
            _difficility = Difficility;
            _paterns = Paterns;
            _id = Id;
            _fabricName = FabricName;
        }
        private string _fabricName;
        public string FabricName { get {return _fabricName; } set { _fabricName = value;} }
    }

    class Lab2 : ILab
    {
        private int _difficility;
        public int Difficility { get { return _difficility; } set { _difficility = value; } }
        private List<String> _paterns;
        public List<String> Paterns { get { return _paterns; } set { _paterns = value; } }
        private int _id;
        public int Id { get { return _id; } set { _id = value; } }
        public Lab2(int Difficility, List<String> Paterns, int Id, List<String> Figures)
        {
            _difficility = Difficility;
            _paterns = Paterns;
            _id = Id;
            _figures = Figures;
        }
        private List<String> _figures { get; set; }
        public List<String> Figures { get { return _figures; } set { _figures = value; } }
    }

    class Lab3 : ILab
    {
        private int _difficility;
        public int Difficility { get { return _difficility; } set { _difficility = value; } }
        private List<String> _paterns;
        public List<String> Paterns { get { return _paterns; } set { _paterns = value; } }
        private int _id;
        public int Id { get { return _id; } set { _id = value; } }
        public Lab3(int Difficility, List<String> Paterns, int Id, List<String> SortMethods)
        {
            _difficility = Difficility;
            _paterns = Paterns;
            _id = Id;
            _sortMethods = SortMethods;
        }
        private List<String> _sortMethods { get; set; }
        public List<String> SortMethods { get { return _sortMethods; } set { _sortMethods = value; } }  
    }

    class Lab4 : ILab
    {
        private int _difficility;
        public int Difficility { get { return _difficility; } set { _difficility = value; } }
        private List<String> _paterns;
        public List<String> Paterns { get { return _paterns; } set { _paterns = value; } }
        private int _id;
        public int Id { get { return _id; } set { _id = value; } }
        public Lab4(int Difficility, List<String> Paterns, int Id)
        {
            _difficility = Difficility;
            _paterns = Paterns;
            _id = Id;
        }
    }

    class Lab5 : ILab
    {
        private int _difficility;
        public int Difficility { get { return _difficility; } set { _difficility = value; } }
        private List<String> _paterns;
        public List<String> Paterns { get { return _paterns; } set { _paterns = value; } }
        private int _id;
        public int Id { get { return _id; } set { _id = value; } }
        public Lab5(int Difficility, List<String> Paterns, int Id, string ShopName)
        {
            _difficility = Difficility;
            _paterns = Paterns;
            _id = Id;
            _shopName = ShopName;
        }
        private string _shopName;
        public string ShopName { get { return _shopName; } set { _shopName = value; } }
    }
}

