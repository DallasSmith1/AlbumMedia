   M S B A M L   `   `   `  ����E  AAlbumMedia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:AlbumMedia
AlbumMedia  5          AlbumMedia.Profile   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:AlbumMedia     5      $	��750��5      $	��450��6     N� Title$  Profile��5	      .��5      �  � RowDefinitions 5   
   �� 5      $	��10* �6   �� 5      $��4* �6   �� 5      $��4* �6   �� 5      $��4* �6   �� 5      $��4* �6   �� 5      $��4* �6   �� 5      $��4* �6   �� 5      $	��10* �6    � ColumnDefinitions 5   
   �� 5      $	��10* �6   �� 5      $	��13* �6   �� 5      $	��10* �6   .+�5   
   ��    MovieDescription#��[  6   $��0��6:   $
��Id: ��6J   $��right=�6Y   $��1��6u   $��Center=�6�   �� 5   
   -   5         ��Name$ lblId��5   8     MovieAttribute#��[ 6   $��1��6G   $��Label��6W   $
��Left=�6g   $��0,0,0,0q�6�   $��1��6�   $��Center=�6�   �� 5   
   #��[  6   $��0��6:   $��	Username:��6J   $��Right=�6^   $��0,0,0,0q�6z   $��2��6�   $��Center=�6�   �� 5   
   -   5        $ lblUsername��5   8   #��[ 6   $��1��6M   $��Label��6]   $
��Left=�6m   $��0,0,0,0q�6�   $��2��6�   $��Center=�6�   �� 5   
   #��[  6   $��0��6:   $��	Password:��6J   $��Right=�6^   $��0,0,0,0q�6z   $��3��6�   $��Center=�6�   �� 5    
   -   5        $ lblPassword��5    8   #��[ 6   $��1��6M   $��Label��6]   $
��Left=�6m   $��0,0,0,0q�6�   $��3��6�   $��Center=�6�   �� 5!   
   -   5         ��Name$ btnShow��5!   1    
 Modern#��[ 6   $��1��6B   $
��Show��6R   $��Right=�6a   $��0,0,0,0q�6}   $��3��6�   $��Center=�6�   $��71��6�   6�   �� 5"   
   -   5        $ btnEdit��5"   1   #��[ 6   $��2��6B   $
��Edit��6R   $
��Left=�6a   $��3��6|   $��Center=�6�   $��80��6�   6�   �� 5#   
   #��[  6   $��0��6:   $��Account Type:��6J   $��Right=�6b   $��0,0,0,0q�6~   $��4��6�   $��Center=�6�   �� 5$   
   -   5        $ lblType��5$   8   #��[ 6   $��1��6I   $��Label��6Y   $
��Left=�6i   $��0,0,0,0q�6�   $��4��6�   $��Center=�6�   �� 5%   
   -   5        $ btnEditMovies��5%   1   #��[ 6   $��1��6H   $��Edit Movies��6X   $��Center=�6n   $��6��6�   $��Center=�6�   $	��134��6�   $y�Hidden=�6�   6�   �� 5&   
   -   5         ��Name$ tbxPassword��5&       	 Input#��[ 6'   $��1��6F   $
��Left=�6V   $��5,0,0,0q�6q   $��3��6�    �� TextWrapping$
 Wrap=�6�   $�� ��6�   $��Center=�6�   $	��210��6�   $y�Hidden=�6�   �� 5'   
   -	   5        $ 	btnCancel��5'      #��[ 6$   $��2��6D   $��Cancel��6T   $
��Left=�6e   $��80,0,0,0q�6�   $��3��6�   $��Center=�6�   $��80��6�   $y�Hidden=�6�   6�   �� 5(   
   -
   5        $ 	btnDelete��5(   1   #��[ 6   $��1��6D   $��Delete Account��6T   $��Center=�6m   $��7��6�   $	��Top=�6�   $	��172��6�   $y�Visible=�6�   $��0,10,0,0q�6�   �� 5)   
   #��[  6   $��0��6:   $��Email:��6J   $
��Left=�6[   $��	176,0,0,0q�6v   $��5��6�   $��Center=�6�   �� 5*   
   -   5        $ lblEmail��5*   8   #��[ 6   $��Label��6J   $
��Left=�6Z   $��5��6u   $��Center=�6�   $��	227,0,0,0q�6�   $��2��6�   5+      5,      