   M S B A M L   `   `   `  ���� E  AAlbumMedia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:AlbumMedia
AlbumMedia      AlbumMedia.Layout   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     *localclr-namespace:AlbumMedia       N� Title$  Layout��$
��auto��$
��auto��.��]� -    ]�Name$ dpnlMain����.  .+��� $��1q�
�������$	��186��._�� $
��Left=� � RowDefinitions �� �� $��5* �.+��� -    ��Name$ imgLogo�� � Cursor$
 Hand��$��Center=�$	��104��$��Center=�$	��186��$��/images/AMLogo.png�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect  ��    ModernScrollView#��[  $��1��$
��Auto=�$��Disabled=�.���� -    ��Name$ 
pnlLeftNav��$��Center=��� $��1q�
�������$��88��$	��Top=�._�� -    �Name$ 	pnlTopNav�� � ColumnDefinitions �� $	��15* ��� $	��15* ��� $	��28* ��� $	��15* ��� $	��27* �.+��� -   	 ��Name$	 	btnMovies��  TransparentHeader#��[ $��Movies��$��Center=�$��Center=�$��88��$	��154���� -   $	 	btnPhotos��#��[ $��1��$��Photos��$��Center=�$��Center=�$��88��$	��174���� -   $	 	btnShared��#��[ $��2��$��Shared Photos��$��Center=�$��Center=�$��88��$	��312���� -   $	 
btnProfile��#��[ $��3��$��Profile��$��Center=�$��Center=�$��88��$	��174��� -	   $ grdLog��$��4�� �� �� .+��� -
   $	 btnLog��#��[ $��Login��$��Center=�$��Center=�$��88��$	��124���� -   
 ��Name$
 lblLoggedInUser��  MovieAttribute#��[ $�� ��$��1��$��Center=��� $��Bottom=�$��1q�
��������� -    ��Name$ 	scrLayout��#��[  $
��Auto=�$
��Auto=�$	��Top=�.��� -   $ grdFrame��$	��Top=� �� $��5* ��� $	��90* ��� $��5* �.+� � -     �Name$ frmMain��$��1��$�� ��  � NavigationUIVisibility$ Hidden=�$��Center=�$	��Top=�$	��Top=�$��Center=�