
        private const string URL = "https://www.data.gouv.fr/fr/datasets/r/15ebb66f-a235-45a3-8ad7-639d0e5cc21d";

        public static async Task<IndiceAir> GetDataAir()
		{
			IndiceAir data = null;

			try
			{
				string dump = await GetData(URL);
				data = JsonConvert.DeserializeObject<IndiceAir>(dump);
			}
			catch (Exception exp)
			{
				Console.WriteLine(exp.Message);
			}

			return data;
        }

		private static async Task<string> GetData(string url)
		{
			try
			{
				if (string.IsNullOrEmpty(url)) { return null; }
				WebRequest request = WebRequest.Create(url);

				using (WebResponse response = await request.GetResponseAsync())
				{
					Console.WriteLine(((HttpWebResponse)response).StatusDescription);
					Stream dataStream = response.GetResponseStream();
					using (StreamReader reader = new StreamReader(dataStream))
					{
						return reader.ReadToEnd();
					}
				}
			}
			catch (Exception exp)
			{
				Console.Write("get data " + url + " " + exp.Message);
			}
			return null;
		}



# -------------------------- db declarations : 

        public static string DatabaseFilename = "XANTI.mydb.db3";
        public static SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }



# ------------------------------------- controler db


        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(App.DatabasePath, App.Flags);
        });

        public static SQLiteAsyncConnection MyDatabase => lazyInitializer.Value;

        static ControlerDB()
        {
            InitiateDatabase();
        }

        public static void AddData()
        {
            object obj = null;
            MyDatabase.UpdateAsync(obj);
        }

        private static void InitiateDatabase()
        {
            var fileName = App.DatabasePath;
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(fileName))
            {
                if (stream == null)
                {
                    throw new FileNotFoundException("Cannot find mappings file.", fileName);
                }
                else
                {
                    using (BinaryReader br = new BinaryReader(stream))
                    using (BinaryWriter bw = new BinaryWriter(new FileStream(App.DatabasePath, FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int len = 0;
                        while ((len = br.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            bw.Write(buffer, 0, len);
                        }
                    }
                }
            }
        }








