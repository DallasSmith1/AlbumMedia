   M S B A M L   `   `   `  ���� T  PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  E AAlbumMedia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:AlbumMedia
AlbumMedia    AlbumMedia.MoviePlayer   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Kmah;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     *localclr-namespace:AlbumMedia     -     N�Name$  MoviePlayer1�� N� Title$ MoviePlayer��$
��auto��$
��auto��.���  � RowDefinitions �� $��1* ��� $	��10* ��� $
��1.5* �.+�r� -    r�Name$ mdeMoviePlayer��$��Center=�$
��auto��$��Center=�$
��auto��$��3���� -    ��Name$ sdrMovieProgess��   MahApps.Styles.Slider.Flat#��[  $��Center=�$��0,0,0,40q�$��Bottom=�$	��720�� � Cursor$
 Hand��$��0��$��3��$��2�����	#CCFF00DE|�.  �� -    ��Name$ 	btnBack30��  VideoSkipLeft#��[ $��Button��$��Center=�$��	0,0,100,5q�$��Bottom=�$��1��$��3��$��38��$��37��|�.  �� -   $ btnForward30��  VideoSkipRight#��[ $��Button��$��3��$��Center=�$��	100,0,0,5q�$��Bottom=�$��1��$��39��$��37��|�.  �� -   $ btnPause��  
VideoPause#��[ $��Button��$��3��$��Center=�$��0,0,0,10q�$��Bottom=�$��1��$��29��$��31��|�.  �� -   $ btnClose�� 	 Close#��[ $��Button��$
��Left=�$	��Top=�$��34��$��31��|�.  �� -    ��Name$ lblMovieTitle��$��0��  
MovieTitle#��[ $��Label��$
��Left=�$��31,0,0,0q�$	��Top=�$��3��$	��706��� $��2�� � ColumnDefinitions �� $��1* ��� $��1* ��� $	��11* ��� $��1* ��� $��1* �.+��� -	   $ lblTotalTime��$��3��$��00:00:00��$
��Left=�$��0,0,0,35q�$��Bottom=�
�������$��2���� -
   $ lblCurrentTime��$��1��$��00:00:00��$��Right=�$��0,0,0,35q�$��Bottom=�
�������$��2���� -   $ btnSound��  
VideoSound#��[ $��2��$��3��$��Button��$
��Left=�$��0,0,0,4q�$��Bottom=�$��31��$��28��|�.  �� -   $ 	sdrVolume��#��[  $��3��$��2��$
��Left=�$��	42,0,0,11q�$��Bottom=�$	��120�����	#CCFF00DE	 � Value$	 50Q�|�.  �� -   $ btnFullscreen��  VideoFullScreen#��[ $��2��$��3��$��Button��$��Right=�$��0,0,10,5q�$��Bottom=�$��31��$��30��|�.  