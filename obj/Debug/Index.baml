   M S B A M L   `   `   `  ����E  AAlbumMedia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:AlbumMedia
AlbumMedia  5          AlbumMedia.Index   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:AlbumMedia     5      U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com  5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5        N� Title$  Index��5      $
��auto��5      $
��auto��6   .��5      � -   5         �Name$ grdMain��5       � RowDefinitions 5   
   �� 5      $	��45* �6   �� 5      $
��151* �6   �� 5      $	��29* �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ 
imgLoading��5      $��1��6$   $��1��65   "  WpfAnimatedGif.ImageBehavior   AnimatedSource$ /images/loading.gif��6B   $	��134��6y   $	��134��6�   $��100.5��6�   $��100.5��6�   $��171,191,175,55q�6�   $y�Hidden=�6�   $��2��6�   �� 5   
   -   5        $ imgLogo��5      $��Center=�6!   $	��109��6>   $��0,39,0,0q�6K   $	��Top=�6]   $	��196��6u   $��/images/AMLogo.png��6�   $��1��6�   $��1��6�   �� 5   
   -   5         ��Name$ 
btnConnect��5       
  Modern#��[  6%   $��Connect��6F   $��Center=�6X   $	��Top=�6u   $��35��6�   $	��100��6�   $��1��6�   $��1��6�   $��	0,171,0,0q�6�   �� 5   
   -   5         ��Name$ lblError��5        MovieDescription#��[ 6"   $��1��6L   $�� ��6\   $��Center=�6g   $��	0,218,0,0q�6�   $��1��6�   $	��Top=�6�   5       5!      