   M S B A M L   `   `   `  ����E  AAlbumMedia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:AlbumMedia
AlbumMedia  5          AlbumMedia.Layout   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:AlbumMedia     5        N� Title$  Layout��5      $
��auto��6   $
��auto��6#   .��5	      ]� -   5         ]�Name$ dpnlMain��5	      ��.  .+�5
   
   �� $��1q�6   
�������$	��186��6=   ._�5      � $
��Left=�6    � RowDefinitions 5      �� 5      �� 5      $��5* �6$   .+�5      �� -   5         ��Name$ imgLogo��5       � Cursor$
 Hand��6)   $��Center=�67   $	��104��6T   $��Center=�6a   $	��186��6|   $��/images/AMLogo.png��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      5      �� 5         ModernScrollView#��[  6   $��1��6I   $
��Auto=�6V   $��Disabled=�6y   .��5      �� -   5         ��Name$ 
pnlLeftNav��5      $��Center=�62   5      5      5      5      �� 5   
   $��1q�6   
�������$��88��6=   $	��Top=�6I   ._�5      � -   5         �Name$ 	pnlTopNav��5       � ColumnDefinitions 5      �� 5      $	��15* �6'   �� 5      $	��15* �6'   �� 5       $	��28* �6'   �� 5!      $	��15* �6'   �� 5"      $	��27* �6'   .+�5$      �� -   5        	 ��Name$	 	btnMovies��5$        TransparentHeader#��[ 6,   $��Movies��6W   $��Center=�6h   $��Center=�6�   $��88��6�   $	��154��6�   6�   �� 5%      -   5        $	 	btnPhotos��5%      #��[ 6,   $��1��6W   $��Photos��6g   $��Center=�6x   $��Center=�6�   $��88��6�   $	��174��6�   6�   �� 5&      -   5        $	 	btnShared��5&      #��[ 6,   $��2��6W   $��Shared Photos��6g   $��Center=�6   $��Center=�6�   $��88��6�   $	��312��6�   6�   �� 5'      -   5        $	 
btnProfile��5'      #��[ 6-   $��3��6X   $��Profile��6h   $��Center=�6z   $��Center=�6�   $��88��6�   $	��174��6�   6�   � 5(      -	   5        $ grdLog��5(      $��4��6'    5)      �� 5*      �� 5+      .+�5-      �� -
   5        $	 btnLog��5-   H   #��[ 6   $��Login��6X   $��Center=�6h   $��Center=�6�   $��88��6�   $	��124��6�   6�   �� 5.      -   5        
 ��Name$
 lblLoggedInUser��5.   D     MovieAttribute#��[ 6   $�� ��6]   $��1��6h   $��Center=�6u   5/      50      51      �� 52   
   $��Bottom=�6   $��1q�6)   
�������54      �� 55   
   -   5         ��Name$ 	scrLayout��55      #��[  6*   $
��Auto=�6T   $
��Auto=�6y   $	��Top=�6�   .��56   
   � -   5        $ grdFrame��56      $	��Top=�6!    57      �� 58      $��5* �6#   �� 59      $	��90* �6#   �� 5:      $��5* �6#   .+�5=       � -   5          �Name$ frmMain��5=   $   $��1��6   $�� ��65     � NavigationUIVisibility$ Hidden=�6@   $��Center=�6`   $	��Top=�6}   $	��Top=�6�   $��Center=�6�   5>      5?      5@      5A      