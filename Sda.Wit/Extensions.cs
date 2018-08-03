using System.Windows;
using System.Windows.Media;

namespace Sda.Wit
{
	public static class Extensions
	{
		public static UIElement FindUid(this DependencyObject parent, string uid)
		{
			var count = VisualTreeHelper.GetChildrenCount(parent);
			if (count == 0) return null;

			for (int i = 0; i < count; i++)
			{
				var el = VisualTreeHelper.GetChild(parent, i) as UIElement;
				if (el == null) continue;

				if (el.Uid == uid) return el;

				el = el.FindUid(uid);
				if (el != null) return el;
			}
			return null;
		}
	}
}
