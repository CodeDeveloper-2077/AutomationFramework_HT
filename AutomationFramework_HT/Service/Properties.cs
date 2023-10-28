namespace AutomationFramework_HT.Service
{
    public static class Properties
    {
        private static readonly string _path = Directory.GetParent(Directory.GetCurrentDirectory())
                                                .Parent
                                                .Parent
                                                .Parent.FullName + @"\AutomationFramework_HT\Resources\dev.properties";
        public static Dictionary<string, string> GetProperty()
        {
            var data = new Dictionary<string, string>();
            foreach (var row in File.ReadAllLines(_path))
                data.Add(row.Split('=')[0], string.Join("=", row.Split('=').Skip(1).ToArray()));

            return data;
        }
    }
}
