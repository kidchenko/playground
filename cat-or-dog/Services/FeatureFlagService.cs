using System;
using System.Threading.Tasks;
using BulletTrain;

namespace cat_or_dog.Services
{
    public class FeatureFlagService
    {
        private BulletTrainClient _bulletClient;

        public FeatureFlagService()
        {
            BulletTrainConfiguration configuration = new BulletTrainConfiguration()
            {
                ApiUrl = "https://api.flagsmith.com/api/v1/",
                EnvironmentKey = "NxFKWBbA49w6KME69YGBYN"
            };
            _bulletClient = new BulletTrainClient(configuration);
        }

        public async Task<bool> HasFeatureFlag(string featureId)
        {
            return await _bulletClient.HasFeatureFlag(featureId) ?? false;
        }

        public Task<string> GetFeatureValue(string featureId)
        {
            return _bulletClient.GetFeatureValue(featureId, Guid.NewGuid().ToString() );
        }
    }
}
