using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Application.UnitTests.TestUtils.Constants;
using BuberDinner.Domain.Menu.Entities;

namespace BuberDinner.Application.UnitTests.Menus.Commands.TestUtils
{
    public static class CreateMenuCommandUtils
    {
        public static CreateMenuCommand CreateCommand(
            List<MenuSectionCommand>? sections = null
        ) =>
            new CreateMenuCommand(
                Constants.Host.Id.ToString()!,
                Constants.Menu.Name,
                Constants.Menu.Description,
                sections ?? CreateSectionsCommand()
            );

        public static List<MenuSectionCommand> CreateSectionsCommand(
            int sectionCount = 1,
            List<MenuItemCommand>? items = null
            ) =>
            Enumerable.Range(0, sectionCount)
                .Select(index => new MenuSectionCommand(
                    Constants.Menu.SectionNameFromIndex(index),
                    Constants.Menu.SectionDescriptionFromIndex(index),
                    items ?? CreateItemsCommand()
                ))
                .ToList();

        public static List<MenuItemCommand> CreateItemsCommand(int itemsCount = 1) =>
            Enumerable.Range(0, itemsCount)
                .Select(index => new MenuItemCommand(
                    Constants.Menu.ItemNameFromIndex(index),
                    Constants.Menu.ItemDescriptionFromIndex(index)
                ))
                .ToList();
    }
}