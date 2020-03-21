using System;

namespace HqFilling.Model
{
    public class DdlModel
    {
        public int Key { get; set; }         
        public string Value { get; set; } 

        public DdlModel() { }
        public DdlModel(int key, string value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}
