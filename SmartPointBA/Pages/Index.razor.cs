namespace SmartPointBA.Pages;

public partial class Index
{
    public Index()
    {
        Categories = new List<Category>();

        Task.Run(async () =>
        {
            await LoadCategories();
        });
    }

    List<Category> Categories { get; set; }

    private async Task LoadCategories()
    {
        try
        {
            var response = await ContentService.Instance().GetItemsAsync<Category>("api/Categories/LoadCategories");

            if (response != null)
            {
                foreach (var item in response) 
                    Categories.Add(item);   
            }
        }
        catch { }
    }
}
