using Abp.MultiTenancy;
using System.Collections.Generic;
using System.Linq;
using tmss.Authorization;

namespace tmss.DashboardCustomization.Definitions
{
    public class DashboardConfiguration : tmssServiceBase
    {
        public List<DashboardDefinition> DashboardDefinitions { get; } = new List<DashboardDefinition>();

        public List<WidgetDefinition> WidgetDefinitions { get; } = new List<WidgetDefinition>();

        public List<WidgetFilterDefinition> WidgetFilterDefinitions { get; } = new List<WidgetFilterDefinition>();

        public DashboardConfiguration()
        {
            #region FilterDefinitions

            // These are global filter which all widgets can use
            var dateRangeFilter = new WidgetFilterDefinition(
                tmssDashboardCustomizationConsts.Filters.FilterDateRangePicker,
                "FilterDateRangePicker"
            );
            var widgetFilter = new WidgetFilterDefinition(
            tmssDashboardCustomizationConsts.Filters.WidgetFilter, "FilterHelloWorld"
            );

            WidgetFilterDefinitions.Add(dateRangeFilter);
            WidgetFilterDefinitions.Add(widgetFilter);

            // Add your filters here

            #endregion




          


            #region HostWidgets

            var HostWidgetsDefaultPermission = new List<string>
            {
                AppPermissions.Pages_Administration_Host_Dashboard
            };

            #endregion





        }

    }
}
