   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      E AAlbumMedia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:AlbumMedia
AlbumMedia 5         AlbumMedia.MoviePlayer   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Kmah;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      *localclr-namespace:AlbumMedia     5      -   5          N�Name$  MoviePlayer1��5       N� Title$ MoviePlayer��5	      $
��auto��6A   $
��auto��6O   .��5
      �  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $	��10* �6   �� 5      $
��1.5* �6   .+�5   
   r� -   5         r�Name$ mdeMoviePlayer��5      $��Center=�6/   $
��auto��6L   $��Center=�6Z   $
��auto��6u   $��3��6�   6�   �� 5   
   -   5         ��Name$ sdrMovieProgess��5         MahApps.Styles.Slider.Flat#��[  6*   $��Center=�6^   $��0,0,0,40q�6{   $��Bottom=�6�   $	��720��6�    � Cursor$
 Hand��6�   $��0��6�   $��3��6�   $��2��6�   ���	#CCFF00DE|�.  6a  �� 5   
   -   5         ��Name$ 	btnBack30��5        VideoSkipLeft#��[ 6$   $��Button��6K   $��Center=�6\   $��	0,0,100,5q�6y   $��Bottom=�6�   $��1��6�   $��3��6�   $��38��6�   $��37��6�   |�.  6�   �� 5   
   -   5        $ btnForward30��5        VideoSkipRight#��[ 6'   $��Button��6O   $��3��6`   $��Center=�6m   $��	100,0,0,5q�6�   $��Bottom=�6�   $��1��6�   $��39��6�   $��37��6�   |�.  6�   �� 5   
   -   5        $ btnPause��5        
VideoPause#��[ 6#   $��Button��6G   $��3��6X   $��Center=�6e   $��0,0,0,10q�6�   $��Bottom=�6�   $��1��6�   $��29��6�   $��31��6�   |�.  6�   �� 5   
   -   5        $ btnClose��5       	 Close#��[ 6#   $��Button��6B   $
��Left=�6S   $	��Top=�6n   $��34��6�   $��31��6�   |�.  6�   �� 5   
   -   5         ��Name$ lblMovieTitle��5      $��0��6'     
MovieTitle#��[ 67   $��Label��6[   $
��Left=�6k   $��31,0,0,0q�6�   $	��Top=�6�   $��3��6�   $	��706��6�   � 5   
   $��2��6    � ColumnDefinitions 5      �� 5      $��1* �6#   �� 5      $��1* �6#   �� 5      $	��11* �6#   �� 5      $��1* �6#   �� 5      $��1* �6#   .+�5      �� -	   5        $ lblTotalTime��5      $��3��6*   $��00:00:00��6:   $
��Left=�6M   $��0,0,0,35q�6h   $��Bottom=�6z   
�������$��2��6�   �� 5       -
   5        $ lblCurrentTime��5       $��1��6,   $��00:00:00��6<   $��Right=�6O   $��0,0,0,35q�6k   $��Bottom=�6}   
�������$��2��6�   �� 5!      -   5        $ btnSound��5!   9     
VideoSound#��[ 6   $��2��6K   $��3��6[   $��Button��6h   $
��Left=�6y   $��0,0,0,4q�6�   $��Bottom=�6�   $��31��6�   $��28��6�   |�.  6�   �� 5"      -   5        $ 	sdrVolume��5"   I   #��[  6   $��3��6\   $��2��6i   $
��Left=�6y   $��	42,0,0,11q�6�   $��Bottom=�6�   $	��120��6�   ���	#CCFF00DE	 � Value$	 50Q�6�   |�.  6  �� 5#      -   5        $ btnFullscreen��5#        VideoFullScreen#��[ 6,   $��2��6U   $��3��6e   $��Button��6r   $��Right=�6�   $��0,0,10,5q�6�   $��Bottom=�6�   $��31��6�   $��30��6�   |�.  6�   5$      5%      5&      