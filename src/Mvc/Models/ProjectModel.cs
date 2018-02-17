using Amazon.DynamoDBv2.DataModel;

namespace DotNetDeployments.Models 
{    
    [DynamoDBTable("Projects")] 
    public class ProjectModel 
    { 
        [DynamoDBHashKey]
        public string SolutionName { get; set; } 
        
        [DynamoDBRangeKey]
        public string ProjectName { get; set; }

        public ProjectType ProjectType { get; set; }

        public string AwsAppName { get; set; }

        public ProjectModel()
        {
            AwsAppName = $"{SolutionName}-{ProjectName}";
        }
    } 
 }
