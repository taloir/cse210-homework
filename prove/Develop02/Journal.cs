public class Journal
    {
        public List<Entry> _Entries = new List<Entry>();
        public string _Name;

        public void DisplayEntries(){
            foreach(Entry e in _Entries){
                e.DisplayEntry();
            }
        }
        public void AddEntry(Entry entry){
            _Entries.Add(entry);
        }
    }