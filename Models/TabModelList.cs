using System.Collections.Generic;
using AnimeList.Controls;

namespace AnimeList.Models
{
    public class TabModelList
    {
        public List<Controls.TabControl> TabList;

        public TabModelList()
        {
            TabList = new List<TabControl>();
        }

        public Controls.TabControl GetActive() => TabList.Find(x => x.Active == true) ?? null;
           
        
    }
}