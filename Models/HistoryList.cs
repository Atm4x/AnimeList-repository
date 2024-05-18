using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static AnimeList.Models.AnimeListConfig;

namespace AnimeList.Models
{
    public class HistoryList
    {
        public List<HistoryModel> HList;

        public HistoryList()
        {
            HList = new List<HistoryModel>();
        }

        public void SetHistoryList(List<HistoryModel> historyList)
        {
            HList = historyList;
        }
    }

    public class HistoryModel
    {
        public List<IAction> HList { get; set; }

        public Controls.TabControl Tab { get; set; }


        public int CurrentPosition = 0;

        public void AddAction(IAction action)
        {
            if (CurrentPosition < HList.Count)
                HList.RemoveRange(CurrentPosition, HList.Count-CurrentPosition);
            else CurrentPosition = HList.Count;
            HList.Add(action);
            CurrentPosition++;
        }

        public HistoryModel()
        {

        }

        public void GoForward()
        {
            if (CurrentPosition + 1 > HList.Count)
                return;
            CurrentPosition++;
            HList[CurrentPosition - 1].Do();
        }

        public void GoBack()
        {
            if (CurrentPosition < 1)
                return;
            HList[CurrentPosition - 1].Undo();
            CurrentPosition--;
        }
    }

    public interface IAction
    {
        public AnimeList AnimeList { get; set; }

        abstract void Do();
        abstract void Undo();
    }

    public class AddAction : IAction
    {
        public AnimeModel AModel { get; set; }
        public AnimeList AnimeList { get; set; }
     

        public AddAction()
        {

        }
        public void Do()
        {
            AnimeList.AddModel(AModel, true);
        }

        public void Undo()
        {
            AnimeList.RemoveModel(AModel.Place, true);
        }
    }

    public class RemoveAction : IAction
    {
        public AnimeModel AModel { get; set; }
        public AnimeList AnimeList { get; set; }


        public RemoveAction()
        {

        }
        public void Do()
        {
            AnimeList.RemoveModel(AModel.Place, true);
        }

        public void Undo()
        {
            AnimeList.AddModel(AModel, true);
        }
    }


    public class EditAction : IAction
    {
        public AnimeModel AModel { get; set; }
        public AnimeList AnimeList { get; set; }

        public int PlaceA { get; set; }
        public int PlaceB { get; set; }
        public string NameA { get; set; }
        public string NameB { get; set; }
        public string CommentA { get; set; }
        public string CommentB { get; set; }
        public int RatingA { get; set; }
        public int RatingB { get; set; }
        public AnimeModelStatus WatchingA { get; set; }
        public AnimeModelStatus WatchingB { get; set; }

        public EditAction()
        {

        }
        public void Do()
        {
            AnimeList.RemoveModel(PlaceA, true);
            AModel.Place = PlaceB;
            AModel.Name = NameB;
            AModel.Status = WatchingB;
            AModel.Rating = RatingB;
            AModel.Comment = CommentB;
            AnimeList.AddModel(AModel, true);
        }

        public void Undo()
        {
            AnimeList.RemoveModel(PlaceB, true);
            AModel.Place = PlaceA;
            AModel.Name = NameA;
            AModel.Status = WatchingA;
            AModel.Rating = RatingA;
            AModel.Comment = CommentA;
            AnimeList.AddModel(AModel, true);
        }
    }

    public class WiFiAction : IAction
    {
        public AnimeList AnimeList { get; set; }
        public AnimeList AnimeListBefore { get; set; }

        public void Do()
        {
            AnimeListBefore.AL = AnimeList.AL;
            AnimeListBefore.SaveChanges();
        }

        public void Undo()
        {
            AnimeList.AL = AnimeListBefore.AL;
            AnimeList.SaveChanges();
        }
    }
}
