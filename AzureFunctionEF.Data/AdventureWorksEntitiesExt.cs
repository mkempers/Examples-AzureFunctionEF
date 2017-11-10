using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctionEF.Data
{
    public partial class AdventureWorksEntities
    {
        public AdventureWorksEntities(string connectString) : base(GetConnectionString(connectString)) {

        }

        public static string GetConnectionString(string connectString)
        {
            const string providerName = "System.Data.SqlClient";
            const string metadata = @"res://*/AdventureWorksModel.csdl|res://*/AdventureWorksModel.ssdl|res://*/AdventureWorksModel.msl";

            // Initialize the connection string builder for the
            // underlying provider.
            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder(connectString)
            {
                // Set the properties for the data source.
                //sqlBuilder.IntegratedSecurity = true;
                MultipleActiveResultSets = true
            };

            // Build the SqlConnection connection string.
            string providerString = sqlBuilder.ToString();

            // Initialize the EntityConnectionStringBuilder.
            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder
            {

                //Set the provider name.
                Provider = providerName,

                // Set the provider-specific connection string.
                ProviderConnectionString = providerString,

                // Set the Metadata location.
                Metadata = metadata
            };

            return entityBuilder.ConnectionString;
        }

    }
}
