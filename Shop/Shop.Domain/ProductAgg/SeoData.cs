using Common.Domain;

namespace Shop.Domain.ProductAgg;

public class SeoData : BaseValueObject
{
    private SeoData()
    {
    }

    public SeoData(string metaTitle, string metaDescription, string metaKeyWord, bool indexPage, string canonical, string schema)
    {
        MetaTitle = metaTitle;
        MetaDescription = metaDescription;
        MetaKeyWord = metaKeyWord;
        IndexPage = indexPage;
        Canonical = canonical;
        Schema = schema;
    }

    public string MetaTitle { get; private set; }
    public string MetaDescription { get; private set; }
    public string MetaKeyWord { get; private set; }
    public bool IndexPage { get; private set; }
    public string Canonical { get; private set; }
    public string Schema { get; private set; }

    public static SeoData CreateEmpty()
    {
        return new SeoData();
    }
}