<Query Kind="Program">
  <NuGetReference Version="6.0.12">Microsoft.AspNetCore.Mvc.NewtonsoftJson</NuGetReference>
  <Namespace>LINQPad.Controls</Namespace>
  <Namespace>System.Collections.ObjectModel</Namespace>
  <Namespace>System.Globalization</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Windows</Namespace>
  <Namespace>System.Windows.Controls</Namespace>
  <Namespace>System.Windows.Controls.Primitives</Namespace>
  <Namespace>System.Windows.Data</Namespace>
  <Namespace>System.Windows.Media</Namespace>
</Query>

void Main()
{
	var window = new Window
	{
		Title = "Mock HTTP Server",
		Width = 800,
		Height = 600,
		FontFamily = new FontFamily("Segoe UI"),
		Background = new SolidColorBrush(Color.FromRgb(40, 44, 52)),
		Foreground = Brushes.WhiteSmoke
	};

	var contentGrid = new Grid
	{
		RowDefinitions =
		{
			new RowDefinition { Height = GridLength.Auto },
			new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
		}
	};

	var routeDefinitionGrid = new DataGrid
	{
		Background = Brushes.Black,
		BorderBrush = Brushes.Gray,
		BorderThickness = new Thickness(1),
		Margin = new Thickness(2, 3, 2, 8),
		HeadersVisibility = DataGridHeadersVisibility.All,
		ColumnHeaderHeight = 30,
		ColumnHeaderStyle = new Style(typeof(DataGridColumnHeader))
		{
			Setters =
			{
				new Setter(DataGridColumnHeader.BackgroundProperty, Brushes.DarkSlateGray),
				new Setter(DataGridColumnHeader.ForegroundProperty, Brushes.White),
				new Setter(DataGridColumnHeader.FontWeightProperty, FontWeights.Bold),
				new Setter(DataGridColumnHeader.PaddingProperty, new Thickness(5))
			}
		},
		RowStyle = new Style(typeof(DataGridRow))
		{
			Setters =
			{
				new Setter(DataGridColumnHeader.BackgroundProperty, Brushes.LightSlateGray)
			}
		}
	};

	var routeDefinitions = new ObservableCollection<RouteDefinition>();
	routeDefinitionGrid.ItemsSource = routeDefinitions;

	var exampleRouteDefinition = new RouteDefinition
	{
		Route = "/api/users",
		Method = "GET",
		StatusCode = HttpStatusCode.OK,
		ResponseBody = "[{ \"id\": 1, \"name\": \"John Doe\" }]"
	};
	routeDefinitions.Add(exampleRouteDefinition);

	var logListBox = new System.Windows.Controls.ListBox
	{
		BorderThickness = new System.Windows.Thickness(1),
		BorderBrush = System.Windows.Media.Brushes.Gray,
		Background = System.Windows.Media.Brushes.Black,
		Foreground = System.Windows.Media.Brushes.White
	};
	logListBox.FontFamily = new System.Windows.Media.FontFamily("Cascadia Code");

	var itemStyle = new System.Windows.Style(typeof(System.Windows.Controls.ListBoxItem));
	itemStyle.Setters.Add(new System.Windows.Setter(System.Windows.Controls.ListBoxItem.PaddingProperty, new System.Windows.Thickness(4)));
	itemStyle.Setters.Add(new System.Windows.Setter(System.Windows.Controls.ListBoxItem.MarginProperty, new System.Windows.Thickness(2)));
	itemStyle.Setters.Add(new System.Windows.Setter(System.Windows.Controls.ListBoxItem.BackgroundProperty, System.Windows.Media.Brushes.LightSlateGray));
	itemStyle.Setters.Add(new System.Windows.Setter(System.Windows.Controls.ListBoxItem.BorderBrushProperty, System.Windows.Media.Brushes.Gray));
	itemStyle.Setters.Add(new System.Windows.Setter(System.Windows.Controls.ListBoxItem.BorderThicknessProperty, new System.Windows.Thickness(1)));
	logListBox.ItemContainerStyle = itemStyle;

	System.Windows.Controls.Grid.SetRow(logListBox, 2);
	contentGrid.RowDefinitions.Add(new System.Windows.Controls.RowDefinition { Height = new System.Windows.GridLength(1, System.Windows.GridUnitType.Star) });
	contentGrid.Children.Add(logListBox);

	var serverStatusLabel = new System.Windows.Controls.Label
	{
		Content = "Server Status: ",
		Margin = new System.Windows.Thickness(10, 10, 0, 10),
		Foreground = System.Windows.Media.Brushes.White,
		FontWeight = System.Windows.FontWeights.Bold,
		FontSize = 16
	};

	var serverStatusContentLabel = new System.Windows.Controls.Label
	{
		Content = "Stopped",
		Margin = new System.Windows.Thickness(10, 10, 10, 10),
		Foreground = System.Windows.Media.Brushes.IndianRed,
		FontWeight = System.Windows.FontWeights.Bold,
		FontSize = 16
	};

	var startStopButton = new System.Windows.Controls.Button
	{
		Content = "Start",
		Margin = new System.Windows.Thickness(10, 10, 10, 10),
		Background = System.Windows.Media.Brushes.DodgerBlue,
		Foreground = System.Windows.Media.Brushes.White,
		BorderBrush = System.Windows.Media.Brushes.DeepSkyBlue,
		BorderThickness = new System.Windows.Thickness(1),
		FontFamily = new System.Windows.Media.FontFamily("Segoe UI"),
		FontSize = 14,
		FontWeight = System.Windows.FontWeights.Bold
	};

	var buttonStyle = new System.Windows.Style(typeof(System.Windows.Controls.Button))
	{
		Setters =
		{
			new System.Windows.Setter(System.Windows.Controls.Button.ForegroundProperty, System.Windows.Media.Brushes.White),
			new System.Windows.Setter(System.Windows.Controls.Button.BackgroundProperty, System.Windows.Media.Brushes.Black),
			new System.Windows.Setter(System.Windows.Controls.Button.BorderThicknessProperty, new System.Windows.Thickness(0)),
			new System.Windows.Setter(System.Windows.Controls.Button.CursorProperty, System.Windows.Input.Cursors.Hand),
			new System.Windows.Setter(System.Windows.Controls.Button.MarginProperty, new System.Windows.Thickness(4)),
			new System.Windows.Setter(System.Windows.Controls.Button.FontWeightProperty, System.Windows.FontWeights.Bold),
			new System.Windows.Setter(System.Windows.Controls.Button.PaddingProperty, new System.Windows.Thickness(50)),
		}
	};

	// Create ControlTemplate for the button with CornerRadius
	var buttonControlTemplate = new System.Windows.Controls.ControlTemplate(typeof(System.Windows.Controls.Button));
	var borderElementFactory = new System.Windows.FrameworkElementFactory(typeof(System.Windows.Controls.Border), "border");
	borderElementFactory.SetValue(System.Windows.Controls.Border.CornerRadiusProperty, new System.Windows.CornerRadius(5));
	borderElementFactory.SetBinding(System.Windows.Controls.Border.BackgroundProperty,
									new System.Windows.Data.Binding("Background")
									{
										RelativeSource = new System.Windows.Data.RelativeSource(System.Windows.Data.RelativeSourceMode.TemplatedParent)
									});
	borderElementFactory.SetBinding(System.Windows.Controls.Border.BorderBrushProperty,
									new System.Windows.Data.Binding("BorderBrush")
									{
										RelativeSource = new System.Windows.Data.RelativeSource(System.Windows.Data.RelativeSourceMode.TemplatedParent)
									});
	borderElementFactory.SetBinding(System.Windows.Controls.Border.BorderThicknessProperty, 
									new System.Windows.Data.Binding("BorderThickness") 
									{ 
										RelativeSource = new System.Windows.Data.RelativeSource(System.Windows.Data.RelativeSourceMode.TemplatedParent) 
									});

	var contentPresenterFactory = new System.Windows.FrameworkElementFactory(typeof(System.Windows.Controls.ContentPresenter));
	contentPresenterFactory.SetValue(System.Windows.Controls.ContentPresenter.MarginProperty, new System.Windows.Thickness(10, 5, 10, 5));
	borderElementFactory.AppendChild(contentPresenterFactory);
	buttonControlTemplate.VisualTree = borderElementFactory;

	// Add the ControlTemplate to the button style
	buttonStyle.Setters.Add(new System.Windows.Setter(System.Windows.Controls.Button.TemplateProperty, buttonControlTemplate));

	// Add hover effect for the button
	var hoverTrigger = new System.Windows.Trigger { Property = System.Windows.Controls.Button.IsMouseOverProperty, Value = true };
	hoverTrigger.Setters.Add(new System.Windows.Setter(System.Windows.Controls.Button.BackgroundProperty, System.Windows.Media.Brushes.DarkGray));
	buttonStyle.Triggers.Add(hoverTrigger);

	startStopButton.Style = buttonStyle;

	HttpListener httpListener = null;
	CancellationTokenSource cancellationTokenSource = null;

	startStopButton.Click += (sender, e) =>
	{
		if (httpListener == null || !httpListener.IsListening)
		{
			httpListener = new HttpListener();
			httpListener.Prefixes.Add("http://localhost:8080/");
			httpListener.Start();
			serverStatusContentLabel.Content = "Running";
			serverStatusContentLabel.Foreground = Brushes.MediumSpringGreen;
			startStopButton.Content = "Stop";

			cancellationTokenSource = new CancellationTokenSource();

			Task.Run(() => HandleRequests(httpListener, cancellationTokenSource.Token, routeDefinitions, window, logListBox));
		}
		else
		{
			httpListener.Stop();
			httpListener = null;

			cancellationTokenSource.Cancel();

			serverStatusContentLabel.Content = "Stopped";
			serverStatusContentLabel.Foreground = Brushes.IndianRed;
			startStopButton.Content = "Start";
		}
	};

	var serverControlPanel = new System.Windows.Controls.StackPanel 
	{ 
		Orientation = System.Windows.Controls.Orientation.Horizontal, 
		VerticalAlignment = System.Windows.VerticalAlignment.Center 
	};
	serverControlPanel.Children.Add(serverStatusLabel);
	serverControlPanel.Children.Add(serverStatusContentLabel);
	serverControlPanel.Children.Add(startStopButton);

	Grid.SetRow(serverControlPanel, 0);
	Grid.SetRow(routeDefinitionGrid, 1);
	contentGrid.Children.Add(serverControlPanel);
	contentGrid.Children.Add(routeDefinitionGrid);

	window.Content = contentGrid;

	window.ShowDialog();
}

async Task HandleRequests(HttpListener httpListener, CancellationToken cancellationToken, ObservableCollection<RouteDefinition> routeDefinitions, Window window, ListBox logListBox)
{
	while (!cancellationToken.IsCancellationRequested)
	{
		try
		{
			var context = await httpListener.GetContextAsync();

			var matchingRoute = routeDefinitions.FirstOrDefault(rd => context.Request.Url.AbsolutePath.Equals(rd.Route) && context.Request.HttpMethod.Equals(rd.Method, StringComparison.OrdinalIgnoreCase));

			if (matchingRoute != null)
			{
				// Set the response status code and send the response body
				context.Response.StatusCode = (int)matchingRoute.StatusCode;

				var logEntry = new LogEntry
				{
					Timestamp = DateTime.Now,
					HttpMethod = context.Request.HttpMethod,
					Url = context.Request.Url.AbsolutePath,
					StatusCode = (HttpStatusCode)context.Response.StatusCode,
				};

				window.Dispatcher.Invoke(() => logListBox.Items.Insert(0, logEntry));
			}
			else
			{
				context.Response.StatusCode = (int)HttpStatusCode.NotFound;
			}

			context.Response.Close();
		}
		catch (HttpListenerException) when (cancellationToken.IsCancellationRequested)
		{
			// Ignore exceptions caused by stopping the HttpListener
		}
		catch (Exception ex)
		{
			ex.Dump();
		}
	}
}

public class RouteDefinition
{
	public string Route { get; set; }
	public string Method { get; set; }
	public HttpStatusCode StatusCode { get; set; }
	public string ResponseBody { get; set; }
}

public class LogEntry
{
	public DateTime Timestamp { get; set; }
	public string HttpMethod { get; set; }
	public string Url { get; set; }
	public HttpStatusCode StatusCode { get; set; }
	public override string ToString() => $"{Timestamp} - {HttpMethod} {Url} - {StatusCode}";
}
