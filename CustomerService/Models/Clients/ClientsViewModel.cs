using ModelEnums;
using WebModels.People;

namespace CustomerService.Models.Clients
{
    public record ClientsViewModel(
        ClientWebModel[] Clients, 
        GenderSeriesItemModel[] GenderSeries, 
        bool IsDataReceivedFromDb);

    public record GenderSeriesItemModel(
        string Gender, 
        double Percents);
}
