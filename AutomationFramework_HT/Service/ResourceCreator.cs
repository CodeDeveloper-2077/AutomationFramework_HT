using AutomationFramework_HT.Model;

namespace AutomationFramework_HT.Service
{
    public class ResourceCreator
    {
        public const int NumberOfInstances = 4;
        public const int NumberOfGPUs = 1;
        public const int CommittedUsage = 1;
        public const string Series = "N1";
        public const string DataCenterLocation = "Frankfurt (europe-west3)";

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
