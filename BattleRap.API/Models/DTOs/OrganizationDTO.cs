using BattleRap.API.Enums;
using BattleRap.API.Repositories;
using BattleRap.API.Repositories.Interfaces;

namespace BattleRap.API.Models.DTOs
{
    public class OrganizationDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public DayOfWeek? DayOfWeek { get; set; }
        public string? Logo { get; set; }
        public string AddressZipCode { get; set; }
        public int AddressCityID { get; set; }
        public string AddressLine1 { get; set; }
        public int AddressNumber { get; set; }
        public string AddressNeighborhood { get; set; }
        public string? AddressLine2 { get; set; }
        public double? AddressLatitude { get; set; }
        public double? AddressLongitude { get; set; }
        public string? YoutubeURL { get; set; }
        public string? FacebookURL { get; set; }
        public string? InstagramURL { get; set; }
        public string? TikTokURL { get; set; }

        public Organization ToOrganization()
        {
            var address = new Address();
            UpdateAddress(address);

            var socialMedias = new List<OrganizationSocialMedia>();
            UpdateAllSocialMedias(socialMedias);

            var info = new OrganizationInfo()
            {
                Address = address,
                SocialMedias = socialMedias,
            };
            UpdateInfo(info);

            return new Organization
            {
                Info = info,
            };
        }

        public void UpdateOrganization(Organization organization)
        {
            UpdateInfo(organization.Info);
            UpdateAddress(organization.Info.Address);
            UpdateAllSocialMedias(organization.Info.SocialMedias);
        }

        private void UpdateInfo(OrganizationInfo info)
        {
            info.Name = Name;
            info.Description = Description;
            info.Logo = Logo;
            info.DayOfWeek = DayOfWeek;
        }

        private void UpdateAddress(Address address)
        {
            address.ZipCode = AddressZipCode;
            address.CityID = AddressCityID;
            address.AddressLine1 = AddressLine1;
            address.Number = AddressNumber;
            address.Neighborhood = AddressNeighborhood;
            address.AddressLine2 = AddressLine2;
            address.Latitude = AddressLatitude;
            address.Longitude = AddressLongitude;
        }

        private void UpdateAllSocialMedias(List<OrganizationSocialMedia> socialMedias)
        {
            if (socialMedias == null)
                socialMedias = new List<OrganizationSocialMedia>();

            UpdateSocialMedia(socialMedias, SocialMediaPlatformEnum.Youtube, YoutubeURL);
            UpdateSocialMedia(socialMedias, SocialMediaPlatformEnum.Instagram, InstagramURL);
            UpdateSocialMedia(socialMedias, SocialMediaPlatformEnum.Facebook, FacebookURL);
            UpdateSocialMedia(socialMedias, SocialMediaPlatformEnum.TikTok, TikTokURL);
        }

        private void UpdateSocialMedia(List<OrganizationSocialMedia> socialMedias, SocialMediaPlatformEnum platform, string? url)
        {
            var currentSocialMedia = FindSocialMedia(socialMedias, platform);

            if (!string.IsNullOrWhiteSpace(url)
                && currentSocialMedia != null)
            {
                currentSocialMedia.SocialMediaProfile.URL = url;
            }

            else if (!string.IsNullOrWhiteSpace(url)
                && currentSocialMedia == null)
            {
                socialMedias.Add(new OrganizationSocialMedia
                {
                    SocialMediaProfile = new SocialMediaProfile
                    {
                        SocialMediaPlatformID = (int)platform,
                        URL = url,
                    }
                });
            }

            else if (string.IsNullOrWhiteSpace(url)
                && currentSocialMedia != null)
            {
                socialMedias.Remove(currentSocialMedia);
            }
        }

        private OrganizationSocialMedia? FindSocialMedia(List<OrganizationSocialMedia> socialMedias, SocialMediaPlatformEnum platform) => socialMedias.FirstOrDefault(x => x.SocialMediaProfile.SocialMediaPlatformID == (int)platform);
    }
}
