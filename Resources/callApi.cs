
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