using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Models
{
    public class UpdateReport
    {
        public string ApplicationTitle { get; set; } = "AnimeList";
        public string ApplicationDescription { get; set; } = "Добро пожаловать в AnimeList!\nЗдесь вы сможете настраивать свои Топы для личной статистики.";
        public string CreateYear { get; set; } = "2022";

        public VersionUpdate VersionUpdate { get; set; } = new VersionUpdate();

    }

    public class VersionUpdate
    {
        public int VersionCount { get; set; } = 4;
        public string VersionControl { get; set; } = "AnimeList 1.2.0 BETA";
        public string VersionTitle { get; set; } = "Добро пожаловать в AnimeList 1.2.0!";
        public string VersionDescription { get; set; } = "В обновлении добавлено много всего интересного! Например, данное окно!\nЗдесь вы увидите то, что появилось с обновлением!\nУдачного использования!";

    }
}
