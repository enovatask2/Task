using Soneta.Business.Licence;
using Soneta.Business.UI;
using Task.Extender;

[assembly: FolderView("Zadanie rekrutacyjne", // wymagane: to jest tekst na kaflu
    Priority = 0,
    Description = "Zadanie rekrutacyjne", 
    BrickColor = FolderViewAttribute.BlueBrick, 
    Icon = "TableFolder.ico" 
)]


[assembly: FolderView("Zadanie rekrutacyjne/Zadanie 1", Priority = 20,
    IconName = "komentarz",
    Description = "Zadanie rektrucyjne",
    ObjectType = typeof(Step3Extender),
    ObjectPage = "Step3.Ogolne.pageform.xml",
    ReadOnlySession = true,
    ConfigSession = false,
    Contexts = new object[] { LicencjeModułu.All }
)]