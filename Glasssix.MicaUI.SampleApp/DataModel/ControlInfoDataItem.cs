using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows;

namespace Glasssix.MicaUI.SampleApp.DataModel
{
    /// <summary>
    /// Generic group data model.
    /// </summary>
    public class ControlInfoDataGroup
    {
        public string Description { get; private set; }

        public string ImageIconPath { get; private set; }

        public string ImagePath { get; private set; }

        public ObservableCollection<ControlInfoDataItem> Items { get; private set; }

        public string Subtitle { get; private set; }

        public string Title { get; private set; }

        public string UniqueId { get; private set; }

        public ControlInfoDataGroup(string uniqueId, string title, string subtitle, string imagePath, string imageIconPath, string description)
        {
            this.UniqueId = uniqueId;
            this.Title = title;
            this.Subtitle = subtitle;
            this.Description = description;
            this.ImagePath = imagePath.Replace("ms-appx://", string.Empty);
            this.ImageIconPath = imageIconPath.Replace("ms-appx://", string.Empty);
            this.Items = new ObservableCollection<ControlInfoDataItem>();
        }

        public override string ToString()
        {
            return this.Title;
        }
    }

    /// <summary>
    /// Generic item data model.
    /// </summary>
    public class ControlInfoDataItem
    {
        public string BadgeString { get; private set; }

        public string Content { get; private set; }

        public string Description { get; private set; }

        public ObservableCollection<ControlInfoDocLink> Docs { get; private set; }

        public string ImageIconPath { get; private set; }

        public string ImagePath { get; private set; }

        public bool IncludedInBuild { get; set; }

        public bool IsNew { get; private set; }

        public bool IsPreview { get; private set; }

        public bool IsUpdated { get; private set; }

        public ObservableCollection<string> RelatedControls { get; private set; }

        public string Subtitle { get; private set; }

        public string Title { get; private set; }

        public string UniqueId { get; private set; }

        public ControlInfoDataItem(string uniqueId, string title, string subtitle, string imagePath, string imageIconPath, string badgeString, string description, string content, bool isNew, bool isUpdated, bool isPreview)
        {
            this.UniqueId = uniqueId;
            this.Title = title;
            this.Subtitle = subtitle;
            this.Description = description;
            this.ImagePath = imagePath.Replace("ms-appx://", string.Empty);
            this.ImageIconPath = imageIconPath.Replace("ms-appx://", string.Empty);
            this.BadgeString = badgeString;
            this.Content = content;
            this.IsNew = isNew;
            this.IsUpdated = isUpdated;
            this.IsPreview = isPreview;
            this.Docs = new ObservableCollection<ControlInfoDocLink>();
            this.RelatedControls = new ObservableCollection<string>();
        }

        public override string ToString()
        {
            return this.Title;
        }
    }

    /// <summary>
    /// Creates a collection of groups and items with content read from a static json file.
    ///
    /// ControlInfoSource initializes with data read from a static json file included in the
    /// project.  This provides sample data at both design-time and run-time.
    /// </summary>
    public sealed class ControlInfoDataSource
    {
        private static readonly object _lock = new object();

        #region Singleton

        private static ControlInfoDataSource _instance;

        public static ControlInfoDataSource Instance
        {
            get
            {
                return _instance;
            }
        }

        private ControlInfoDataSource()
        {
        }

        static ControlInfoDataSource()
        {
            _instance = new ControlInfoDataSource();
        }

        #endregion Singleton

        private IList<ControlInfoDataGroup> _groups = new List<ControlInfoDataGroup>();

        public IList<ControlInfoDataGroup> Groups
        {
            get { return this._groups; }
        }

        private async Task GetControlInfoDataAsync()
        {
            lock (_lock)
            {
                if (this.Groups.Count() != 0)
                {
                    return;
                }
            }

            var dataUri = new Uri("/DataModel/ControlInfoData.json", UriKind.Relative);

            var file = Application.GetResourceStream(dataUri);
            string jsonText = string.Empty;

            using (var reader = new StreamReader(file.Stream))
            {
                await Task.Run(() => jsonText = reader.ReadToEnd());
            }

            var jsonObject = JsonObject.Parse(jsonText);
            JsonArray jsonArray = jsonObject["Groups"].AsArray();

            lock (_lock)
            {
                string pageRoot = "Glasssix.MicaUI.SampleApp.ControlPages.";
                foreach (var groupValue in jsonArray)
                {
                    JsonObject groupObject = groupValue.AsObject();

                    ControlInfoDataGroup group = new ControlInfoDataGroup(groupObject["UniqueId"].GetValue<string>(),
                                                                          groupObject["Title"].GetValue<string>(),
                                                                          groupObject["Subtitle"].GetValue<string>(),
                                                                          groupObject["ImagePath"].GetValue<string>(),
                                                                          groupObject["ImageIconPath"].GetValue<string>(),
                                                                          groupObject["Description"].GetValue<string>());

                    foreach (var itemValue in groupObject["Items"].AsArray())
                    {
                        JsonObject itemObject = itemValue.AsObject();

                        string badgeString = null;

                        bool isNew = itemObject.ContainsKey("IsNew") ? itemObject["IsNew"].GetValue<bool>() : false;
                        bool isUpdated = itemObject.ContainsKey("IsUpdated") ? itemObject["IsUpdated"].GetValue<bool>() : false;
                        bool isPreview = itemObject.ContainsKey("IsPreview") ? itemObject["IsPreview"].GetValue<bool>() : false;

                        if (isNew)
                        {
                            badgeString = "New";
                        }
                        else if (isUpdated)
                        {
                            badgeString = "Updated";
                        }
                        else if (isPreview)
                        {
                            badgeString = "Preview";
                        }

                        var item = new ControlInfoDataItem(itemObject["UniqueId"].GetValue<string>(),
                                                                itemObject["Title"].GetValue<string>(),
                                                                itemObject["Subtitle"].GetValue<string>(),
                                                                itemObject["ImagePath"].GetValue<string>(),
                                                                itemObject["ImageIconPath"].GetValue<string>(),
                                                                badgeString,
                                                                itemObject["Description"].GetValue<string>(),
                                                                itemObject["Content"].GetValue<string>(),
                                                                isNew,
                                                                isUpdated,
                                                                isPreview);

                        {
                            string pageString = pageRoot + item.UniqueId + "Page";
                            Type pageType = Type.GetType(pageString);
                            item.IncludedInBuild = pageType != null;
                        }

                        if (itemObject.ContainsKey("Docs"))
                        {
                            foreach (var docValue in itemObject["Docs"].AsArray())
                            {
                                JsonObject docObject = docValue.AsObject();
                                item.Docs.Add(new ControlInfoDocLink(docObject["Title"].GetValue<string>(), docObject["Uri"].GetValue<string>()));
                            }
                        }

                        if (itemObject.ContainsKey("RelatedControls"))
                        {
                            foreach (var relatedControlValue in itemObject["RelatedControls"].AsArray())
                            {
                                item.RelatedControls.Add(relatedControlValue.GetValue<string>());
                            }
                        }

                        group.Items.Add(item);
                    }
                    if (!Groups.Any(g => g.Title == group.Title))
                    {
                        Groups.Add(group);
                    }
                }
            }
        }

        public async Task<ControlInfoDataGroup> GetGroupAsync(string uniqueId)
        {
            await _instance.GetControlInfoDataAsync();
            // Simple linear search is acceptable for small data sets
            var matches = _instance.Groups.Where((group) => group.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        public async Task<ControlInfoDataGroup> GetGroupFromItemAsync(string uniqueId)
        {
            await _instance.GetControlInfoDataAsync();
            var matches = _instance.Groups.Where((group) => group.Items.FirstOrDefault(item => item.UniqueId.Equals(uniqueId)) != null);
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        public async Task<IEnumerable<ControlInfoDataGroup>> GetGroupsAsync()
        {
            await _instance.GetControlInfoDataAsync();

            return _instance.Groups;
        }

        public async Task<ControlInfoDataItem> GetItemAsync(string uniqueId)
        {
            await _instance.GetControlInfoDataAsync();
            // Simple linear search is acceptable for small data sets
            var matches = _instance.Groups.SelectMany(group => group.Items).Where((item) => item.UniqueId.Equals(uniqueId));
            if (matches.Count() > 0) return matches.First();
            return null;
        }
    }

    public class ControlInfoDocLink
    {
        public string Title { get; private set; }

        public string Uri { get; private set; }

        public ControlInfoDocLink(string title, string uri)
        {
            this.Title = title;
            this.Uri = uri;
        }
    }
}