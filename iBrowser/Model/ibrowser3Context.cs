#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.239
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace iBrowser.Model
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
using System.IO;
using System.IO.IsolatedStorage;
using Microsoft.Phone.Data.Linq.Mapping;
using Microsoft.Phone.Data.Linq;


public class DebugWriter : TextWriter
{
    private const int DefaultBufferSize = 256;
    private System.Text.StringBuilder _buffer;

    public DebugWriter()
    {
        BufferSize = 256;
        _buffer = new System.Text.StringBuilder(BufferSize);
    }

    public int BufferSize
    {
        get;
        private set;
    }

    public override System.Text.Encoding Encoding
    {
        get { return System.Text.Encoding.UTF8; }
    }

    #region StreamWriter Overrides
    public override void Write(char value)
    {
        _buffer.Append(value);
        if (_buffer.Length >= BufferSize)
            Flush();
    }

    public override void WriteLine(string value)
    {
        Flush();

        using(var reader = new StringReader(value))
        {
            string line; 
            while( null != (line = reader.ReadLine()))
                System.Diagnostics.Debug.WriteLine(line);
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
            Flush();
    }

    public override void Flush()
    {
        if (_buffer.Length > 0)
        {
            System.Diagnostics.Debug.WriteLine(_buffer);
            _buffer.Clear();
        }
    }
    #endregion
}


	public partial class ibrowser3Context : System.Data.Linq.DataContext
	{
		
		public bool CreateIfNotExists()
		{
			bool created = false;
			if (!this.DatabaseExists())
			{
				string[] names = this.GetType().Assembly.GetManifestResourceNames();
				string name = names.Where(n => n.EndsWith(FileName)).FirstOrDefault();
				if (name != null)
				{
					using (Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name))
					{
						if (resourceStream != null)
						{
							using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
							{
								using (IsolatedStorageFileStream fileStream = new IsolatedStorageFileStream(FileName, FileMode.Create, myIsolatedStorage))
								{
									using (BinaryWriter writer = new BinaryWriter(fileStream))
									{
										long length = resourceStream.Length;
										byte[] buffer = new byte[32];
										int readCount = 0;
										using (BinaryReader reader = new BinaryReader(resourceStream))
										{
											// read file in chunks in order to reduce memory consumption and increase performance
											while (readCount < length)
											{
												int actual = reader.Read(buffer, 0, buffer.Length);
												readCount += actual;
												writer.Write(buffer, 0, actual);
											}
										}
									}
								}
							}
							created = true;
						}
						else
						{
							this.CreateDatabase();
							created = true;
						}
					}
				}
				else
				{
					this.CreateDatabase();
					created = true;
				}
			}
			return created;
		}
		
		public bool LogDebug
		{
			set
			{
				if (value)
				{
					this.Log = new DebugWriter();
				}
			}
		}
		
		public static string ConnectionString = "Data Source=isostore:/ibrowser3.sdf";

		public static string ConnectionStringReadOnly = "Data Source=appdata:/ibrowser3.sdf;File Mode=Read Only;";

		public static string FileName = "ibrowser3.sdf";

		public ibrowser3Context(string connectionString) : base(connectionString)
		{
			OnCreated();
		}
		
    #region 可扩展性方法定义
    partial void OnCreated();
    partial void InsertMainmenu(Mainmenu instance);
    partial void UpdateMainmenu(Mainmenu instance);
    partial void DeleteMainmenu(Mainmenu instance);
    partial void InsertMainsetting(Mainsetting instance);
    partial void UpdateMainsetting(Mainsetting instance);
    partial void DeleteMainsetting(Mainsetting instance);
    partial void InsertSkinlist(Skinlist instance);
    partial void UpdateSkinlist(Skinlist instance);
    partial void DeleteSkinlist(Skinlist instance);
    #endregion
		
		public System.Data.Linq.Table<Mainmenu> Mainmenu
		{
			get
			{
				return this.GetTable<Mainmenu>();
			}
		}
		
		public System.Data.Linq.Table<Mainsetting> Mainsetting
		{
			get
			{
				return this.GetTable<Mainsetting>();
			}
		}
		
		public System.Data.Linq.Table<Skinlist> Skinlist
		{
			get
			{
				return this.GetTable<Skinlist>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="mainmenu")]
	public partial class Mainmenu : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Pkid;
		
		private string _Desc;
		
		private string _Name;
		
		private string _Img;
		
		private System.Nullable<int> _Sortid;
		
		private string _Url;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnPkidChanging(int value);
    partial void OnPkidChanged();
    partial void OnDescChanging(string value);
    partial void OnDescChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnImgChanging(string value);
    partial void OnImgChanged();
    partial void OnSortidChanging(System.Nullable<int> value);
    partial void OnSortidChanged();
    partial void OnUrlChanging(string value);
    partial void OnUrlChanged();
    #endregion
		
		public Mainmenu()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="pkid", Storage="_Pkid", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Pkid
		{
			get
			{
				return this._Pkid;
			}
			set
			{
				if ((this._Pkid != value))
				{
					this.OnPkidChanging(value);
					this.SendPropertyChanging();
					this._Pkid = value;
					this.SendPropertyChanged("Pkid");
					this.OnPkidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="desc", Storage="_Desc", DbType="NVarChar(100)")]
		public string Desc
		{
			get
			{
				return this._Desc;
			}
			set
			{
				if ((this._Desc != value))
				{
					this.OnDescChanging(value);
					this.SendPropertyChanging();
					this._Desc = value;
					this.SendPropertyChanged("Desc");
					this.OnDescChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="name", Storage="_Name", DbType="NVarChar(100)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="img", Storage="_Img", DbType="NVarChar(100)")]
		public string Img
		{
			get
			{
				return this._Img;
			}
			set
			{
				if ((this._Img != value))
				{
					this.OnImgChanging(value);
					this.SendPropertyChanging();
					this._Img = value;
					this.SendPropertyChanged("Img");
					this.OnImgChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="sortid", Storage="_Sortid", DbType="Int")]
		public System.Nullable<int> Sortid
		{
			get
			{
				return this._Sortid;
			}
			set
			{
				if ((this._Sortid != value))
				{
					this.OnSortidChanging(value);
					this.SendPropertyChanging();
					this._Sortid = value;
					this.SendPropertyChanged("Sortid");
					this.OnSortidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="url", Storage="_Url", DbType="NVarChar(100)")]
		public string Url
		{
			get
			{
				return this._Url;
			}
			set
			{
				if ((this._Url != value))
				{
					this.OnUrlChanging(value);
					this.SendPropertyChanging();
					this._Url = value;
					this.SendPropertyChanged("Url");
					this.OnUrlChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="mainsetting")]
	public partial class Mainsetting : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Nullable<int> _Skinid;
		
		private int _Pkid;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnSkinidChanging(System.Nullable<int> value);
    partial void OnSkinidChanged();
    partial void OnPkidChanging(int value);
    partial void OnPkidChanged();
    #endregion
		
		public Mainsetting()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="skinid", Storage="_Skinid", DbType="Int")]
		public System.Nullable<int> Skinid
		{
			get
			{
				return this._Skinid;
			}
			set
			{
				if ((this._Skinid != value))
				{
					this.OnSkinidChanging(value);
					this.SendPropertyChanging();
					this._Skinid = value;
					this.SendPropertyChanged("Skinid");
					this.OnSkinidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="pkid", Storage="_Pkid", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Pkid
		{
			get
			{
				return this._Pkid;
			}
			set
			{
				if ((this._Pkid != value))
				{
					this.OnPkidChanging(value);
					this.SendPropertyChanging();
					this._Pkid = value;
					this.SendPropertyChanged("Pkid");
					this.OnPkidChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="skinlist")]
	public partial class Skinlist : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Pkid;
		
		private string _SkinName;
		
		private string _SkinFolder;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnPkidChanging(int value);
    partial void OnPkidChanged();
    partial void OnSkinNameChanging(string value);
    partial void OnSkinNameChanged();
    partial void OnSkinFolderChanging(string value);
    partial void OnSkinFolderChanged();
    #endregion
		
		public Skinlist()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="pkid", Storage="_Pkid", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Pkid
		{
			get
			{
				return this._Pkid;
			}
			set
			{
				if ((this._Pkid != value))
				{
					this.OnPkidChanging(value);
					this.SendPropertyChanging();
					this._Pkid = value;
					this.SendPropertyChanged("Pkid");
					this.OnPkidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="skinName", Storage="_SkinName", DbType="NVarChar(100)")]
		public string SkinName
		{
			get
			{
				return this._SkinName;
			}
			set
			{
				if ((this._SkinName != value))
				{
					this.OnSkinNameChanging(value);
					this.SendPropertyChanging();
					this._SkinName = value;
					this.SendPropertyChanged("SkinName");
					this.OnSkinNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="skinFolder", Storage="_SkinFolder", DbType="NVarChar(100)")]
		public string SkinFolder
		{
			get
			{
				return this._SkinFolder;
			}
			set
			{
				if ((this._SkinFolder != value))
				{
					this.OnSkinFolderChanging(value);
					this.SendPropertyChanging();
					this._SkinFolder = value;
					this.SendPropertyChanged("SkinFolder");
					this.OnSkinFolderChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
