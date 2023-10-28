using AutomationFramework_HT.Model;

namespace AutomationFramework_HT.Service
{
    public class ResourceCreator
    {
        public static int NumberOfInstances = int.Parse(Properties.GetProperty()["NumberOfInstances"]);
        public static int NumberOfGPUs = int.Parse(Properties.GetProperty()["NumberOfGPUs"]);
        public static int CommittedUsage = int.Parse(Properties.GetProperty()["CommittedUsage"]);
        public static string Series = Properties.GetProperty()["Series"];
        public static string DataCenterLocation = Properties.GetProperty()["DataCenterLocation"];

        public static ResourceModel CreateResources()
        {
            return new ResourceModel(NumberOfInstances, 
                                     NumberOfGPUs, 
                                     CommittedUsage, 
                                     Series, 
                                     DataCenterLocation
                                     );
        }
    }
}
