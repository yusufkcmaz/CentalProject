using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cental.WebUI.Extansions
{
    public  static class GetEnumValues
    {
        //Enum metodları.
        public static List<SelectListItem>GetEnums<T>()
        {
            var values = Enum.GetValues(typeof(T));
            var SelectList = new List<SelectListItem>();

            foreach (var item in values)
            {

                SelectList.Add(new SelectListItem
                {
                    Text = item.ToString(),
                    Value = item.ToString()

                });

            }

            return SelectList;  
        }

    }
}
