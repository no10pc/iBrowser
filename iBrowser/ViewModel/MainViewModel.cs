using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using iBrowser.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Windows;
namespace iBrowser.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        //private MenuDataContext _dataContext = DataBaseManager.ContactorDataContext;




        private ibrowser3Context _dataContext = new Model.ibrowser3Context(Model.ibrowser3Context.ConnectionString);


        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {

            this.Mainmenus = new ObservableCollection<Mainmenu>();
            this.SaveMenuCommand = new RelayCommand(SaveMenuCommandAction);
            if (this.IsInDesignMode)
            {
                this.Mainmenus.Add(new Mainmenu() { Name = "设计 第一屏", Desc = "测试1Desc" });
                this.Mainmenus.Add(new Mainmenu() { Name = "设计 第二屏", Desc = "测试2Desc" });
            }
            else
            {

                if (_dataContext.CreateIfNotExists())
                {
                    ///初始化QuickLink
                    _dataContext.Mainmenu.InsertOnSubmit(new Mainmenu { Img = "/Skin/Normal/QuickLink_qq.com.png", Name = "QQ", Desc = "QQ", Url = "http://www.qq.com" });
                    _dataContext.Mainmenu.InsertOnSubmit(new Mainmenu { Img = "/Skin/Normal/QuickLink_qzone.png", Name = "QQ空间", Desc = "QQ空间", Url = "http://z.qq.com" });
                    _dataContext.Mainmenu.InsertOnSubmit(new Mainmenu { Img = "/Skin/Normal/QuickLink_t.qq.com.png", Name = "腾讯微博", Desc = "腾讯微博", Url = "http://tt.qq.com" });
                    _dataContext.Mainmenu.InsertOnSubmit(new Mainmenu { Img = "/Skin/Normal/QuickLink_taobao.png", Name = "手机淘宝", Desc = "手机淘宝", Url = "http://www.taobao.com" });
                    _dataContext.Mainmenu.InsertOnSubmit(new Mainmenu { Img = "/Skin/Normal/QuickLink_wangyi.png", Name = "手机网易", Desc = "手机网易", Url = "http://www.163.com" });
                    ///初始化SkinList
                    _dataContext.Skinlist.InsertOnSubmit(
                        new Skinlist { SkinFolder = "skin/Normal/", SkinName = "默认" });
                    _dataContext.Skinlist.InsertOnSubmit(
                        new Skinlist { SkinFolder = "skin/Yellow/", SkinName = "早春三月" });
                    //初始化Setting
                    _dataContext.Mainsetting.InsertOnSubmit(
                        new Mainsetting { Skinid = 2 }
                        );
                    _dataContext.SubmitChanges();




                }

                List<Mainmenu> Mainmenus = _dataContext.Mainmenu.ToList();

                string Skin = _dataContext.Skinlist.Where(x => x.Pkid == _dataContext.Mainsetting.First().Skinid).First().SkinFolder + "bkstyle.jpg";




                Mainmenus.Add(new Mainmenu { Img = "/Skin/Normal/StartPage_AddFav.png", Name = "添加新网址", Desc = "添加新网址" });




                this.Mainmenus = new ObservableCollection<Mainmenu>(Mainmenus);

            }
        }

        /// <summary>
        /// menu
        /// </summary>
        private ObservableCollection<Mainmenu> _fieldMainmenus;
        public ObservableCollection<Mainmenu> Mainmenus
        {
            get
            {
                return _fieldMainmenus;
            }
            set
            {
                if (_fieldMainmenus == value) return;
                _fieldMainmenus = value;
                RaisePropertyChanged("Mainmenus");
            }
        }


        private ObservableCollection<Skinlist> _Skinlists;
        public ObservableCollection<Skinlist> Skinlists
        {
            get
            {
                return _Skinlists;
            }
            set
            {
                if (_Skinlists == value) return;
                _Skinlists = value;
                RaisePropertyChanged("Skinlists");
            }
        }

        /// <summary>
        /// The <see cref="currentSkin" /> property's name.
        /// </summary>
        public const string currentSkinPropertyName = "currentSkin";

        private string _currentSkin;

        /// </summary>
        public string currentSkin
        {
            get
            {
                return _currentSkin;
            }

            set
            {
                if (_currentSkin == value)
                {
                    return;
                }

                var oldValue = _currentSkin;
                _currentSkin = value;

                // Remove one of the two calls below


                // Update bindings, no broadcast
                RaisePropertyChanged(currentSkinPropertyName);

                // Update bindings and broadcast change using GalaSoft.MvvmLight.Messenging
                RaisePropertyChanged(currentSkinPropertyName, oldValue, value, true);
            }
        }


        /// <summary>
        /// InputGroupName
        /// </summary>
        private string _fieldInputScreenName;
        public string InputScreenName
        {
            get
            {
                return _fieldInputScreenName;
            }
            set
            {
                if (_fieldInputScreenName == value) return;
                _fieldInputScreenName = value;
                RaisePropertyChanged("InputMainmenuName");
            }
        }

        /// <summary>
        /// InputGroupDesc
        /// </summary>
        private string _fieldInputScreenDesc;
        public string InputScreenDesc
        {
            get
            {
                return _fieldInputScreenDesc;
            }
            set
            {
                if (_fieldInputScreenDesc == value) return;
                _fieldInputScreenDesc = value;
                RaisePropertyChanged("InpuMainmenuDesc");
            }
        }

        #region commands


        /// <summary>
        /// SaveGroupCommand 
        /// </summary>
        public ICommand SaveMenuCommand { get; private set; }
        private void SaveMenuCommandAction()
        {
            if (string.IsNullOrEmpty(this.InputScreenName))
            {
                MessageBox.Show("组名不能为空");
                return;
            }

            Mainmenu screen = new Mainmenu();
            screen.Name = this.InputScreenName;
            screen.Desc = this.InputScreenDesc;

            _dataContext.Mainmenu.InsertOnSubmit(screen);
            _dataContext.SubmitChanges();

            MessageBox.Show("添加成功");
            this.Mainmenus.Add(screen);
            this.InputScreenName = string.Empty;
            this.InputScreenDesc = string.Empty;
        }

        #endregion

    }
}