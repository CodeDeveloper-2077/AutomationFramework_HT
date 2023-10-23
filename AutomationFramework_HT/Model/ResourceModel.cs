namespace AutomationFramework_HT.Model
{
    public class ResourceModel
    {
        public int NumberOfInstances { get; set; }

        public int NumberOfGPUs { get; set; }

        public int CommittedUsage { get; set; }

        public string Series { get; set; }

        public string DatacenterLocation { get; set; }

        public ResourceModel(int numberOfInstances, 
                             int numberOfGPUs, 
                             int committedUsage, 
                             string series, 
                             string datacenterLocation)
        {
            NumberOfInstances = numberOfInstances;
            NumberOfGPUs = numberOfGPUs;
            CommittedUsage = committedUsage;
            Series = series;
            DatacenterLocation = datacenterLocation;
        }
    }
}
