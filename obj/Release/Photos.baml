   M S B A M L   `   `   `  ���� E  AAlbumMedia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:AlbumMedia
AlbumMedia      AlbumMedia.Photos   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     *localclr-namespace:AlbumMedia     U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com    N� Title$  Photos��.���  � ColumnDefinitions �� $��1* ��� $	��10* ��� $��1* � � RowDefinitions �� $��75 ��� $��1* ��� $	��10* ��� $��1* �.+��� -    ��Name$ 	tbxSearch�� 
  Search#��[  $��Center=�$��0,0,0,0q� �� TextWrapping$
 Wrap=�$��Center=�$	��478��$��1��$��0��� -    �Name$ grdCollumns��$��1��$��2�� �� �� �� �� .+��� -    ��Name$ spnl1��$y�Hidden=��� -   $ spnl2��$��1��$y�Hidden=��� -   $ spnl3��$��2��$y�Hidden=��� -   $ spnl4��$��3��$y�Hidden=��� -    ��Name$ cbxSort��$��1��$��Center=�$��Center=�$	��264��
����p��
������� �� 
IsReadOnly . 	 �� SelectedIndex$	 0��
 � Cursor$

 Hand��$��18(�$��	780,0,0,0q���Z� .@��� ���	#FFDB7093$

 Hand��$ ��Date Photo Taken (New-Old)��
������� �� 
IsSelected . $��18(��� ���	#FFDB7093$

 Hand��$ ��Date Photo Taken (Old-New)��
�������$��18(��� ���	#FFDB7093$

 Hand��$��Date Uploaded (New-Old)��
�������$��18(��� ���	#FFDB7093$

 Hand��$��Date Uploaded (Old-New)��
�������$��18(��� -    ��Name$ 	btnUpload�� 
 Modern#��[ $��1��$��Upload��$
��Left=�$��44,0,0,0q�$��Center=�$��92��$y�Hidden=��� -	    ��Name$ lblImagesPerPage��  MovieDescription#��[ $��1��$��
1-40 of 40��$��Center=�$��0,0,0,0q�$��1��$��Center=�$y�Hidden=��� -
   $ btnNextPage��  NavigateRight#��[ $��1��$��Button��$��Center=�$��	200,0,0,0q�$��1��$��Center=�$��34��$��21��$y�Hidden=��� -   $ btnPreviousPage��{�.    NavigateLeft#��[ $��1��$��Button��$��Center=�$��1��$��Center=�$��34��$��23��$��	0,0,200,0q�$y�Hidden=��� -   $ lblImagesPerPageBottom��#��[ $��1��$��
1-40 of 40��$��Center=�$��3��$��Center=�$y�Hidden=��� -   $ btnNextPageBottom��#��[ $��1��$��Button��$��Center=�$��	200,0,0,0q�$��3��$��Center=�$��34��$��21��$y�Hidden=��� -   $ btnPreviousPageBottom��{�.  #��[ $��1��$��Button��$��Center=�$��3��$��Center=�$��34��$��23��$��	0,0,200,0q�$y�Hidden=��� -    ��Name$ 
imgLoading��$��1��$
��Left=�$	��100��$��
505,29,0,0q�"  WpfAnimatedGif.ImageBehavior   AnimatedSource$ /images/loading.gif��$	��Top=�$	��100��$��2���� -   $ 
cbxPerPage��$��1��$��Center=�$��Center=�$	��190��
����p��
������� . $	 0��$

 Hand��$��	0,0,700,0q�$��18(���Z� .@��� ���	#FFDB7093$

 Hand��$��12 Photos Per Page��
������� . $��18(��� ���	#FFDB7093$

 Hand��$��24 Photos Per Page��
�������$��18(��� ���	#FFDB7093$

 Hand��$��32 Photos Per Page��
�������$��18(��� ���	#FFDB7093$

 Hand��$��40 Photos Per Page��
�������$��18(��� -   $ btnLastPage��  NavigateRightDouble#��[ $��1��$��Button��$��Center=�$��	300,0,0,0q�$��1��$��Center=�$��34��$��21��$y�Hidden=��� -   $ btnFirstPage��  NavigateLeftDouble#��[ $��1��$��Button��$��Center=�$��	0,0,300,0q�$��1��$��Center=�$��34��$��21��{�.  $y�Hidden=��� -   $ btnLastPageBottom��#��[ $��1��$��Button��$��Center=�$��	300,0,0,0q�$��3��$��Center=�$��34��$��21��$y�Hidden=��� -   $ btnFirstPageBottom��#��[ $��1��$��Button��$��Center=�$��	0,0,300,0q�$��3��$��Center=�$��34��$��21��{�.  $y�Hidden=�