   M S B A M L   `   `   `  ����E  AAlbumMedia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:AlbumMedia
AlbumMedia  5      "    AlbumMedia.FileInteractivity   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:AlbumMedia     5      U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com  5        N� Title$  FileInteractivity��5	      $	��514��6!   $	��801��6.   .��5      � .+�5   
   �� -   5         ��Name$ cvsMain��5      $y�Visible=�6"   .+�5      �� -   5         ��Name$ 	btnCancel��5   5    
  Modern#��[  6   $��Cancel��6H   $
��Left=�6Y   $��	10,10,0,0q�6t   $	��Top=�6�   $��35��6�   $��80��6�   6�   �� 5      -   5         ��Name$ lblFilesSelected��5   2     Form#��[ 6   $��Files Selected: 0��6L   $
��Left=�6h   $	��Top=�6�    �� Left$	 318��6�   
 �� Top$	 205��6�   �� 5      -   5        $ btnShare��5   @     ModernLargeShared#��[ 6   $��Share��6R   $ 83��6b   $	 286��6s   $
��Left=�6�   $	��Top=�6�   6�   �� 5      -   5        $ btnDownload��5        ModernLargeDownload#��[ 6*   $	 343��6W   $	 286��6i   $
��Left=�6z   $	��Top=�6�   6�   �� 5      -   5        $ btnHide��5        ModernLargeHide#��[ 6&   $	 213��6O   $	 286��6a   $
��Left=�6r   $	��Top=�6�   6�   �� 5      -   5        $ btnEdit��5        ModernLargeTags#��[ 6&   $	 473��6O   $	 286��6a   $
��Left=�6r   $	��Top=�6�   6�   �� 5      -   5        $ 	btnDelete��5        ModernLargeDelete#��[ 6(   $	 603��6S   $	 286��6e   $
��Left=�6v   $	��Top=�6�   6�   �� 5      -	   5         ��Name$ svrFiles��5      $	��150��6-   $	��780��6:   $ 10��6F   $ 55��6W   $��Center=�6g   $	��Top=�6�   $��Disabled=�6�   $��Hidden=�6�   .��5      �� -
   5         ��Name$ 	spnlFiles��5       �� Orientation$ 
Horizontal=�60   $��Disabled=�6I   $��Disabled=�6}   5      5      �� 5      -   5        	 ��Name$	 rctLeft��5      $	��162��6)   $ -3��66   $ 54��6G   $	��177��6W   $
��Left=�6c   $��Center=�6~   
 J� RenderTransformOrigin$
 0.5,0.5&�6�   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$
 -270Q�6*   T� 5      5      ��5!      �� 5"       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5#      �  � Color$ 	#00000000��6'   � 5$      $ 	#FF131313��6'    � Offset$ 0.677Q�69   5%      5'      �� 5(      -   5        $	 rctRight��5(      $	��162��6*   $	 625��67   $ 47��6I   $	��177��6Y   $
 0.5,0.5&�6e   $
��Left=�6�   $	��Top=�6�   z�5)      V� 5*      .~�5+      �� �� 5,      �� 5-      $	 -90Q�6*   T� 5.      5/      ��51      �� 52      $ 0.5,1&�6*   $ 0.5,0&�6;   .��53      � $ 	#00000000��6'   $
 0.11Q�69   � 54      $ 	#FF131313��6'   $ 0.807Q�69   55      57      �� 58      -   5        $	 rctLeftSlow��58      $	��184��6-   $	 170��6:   ���	#00000000$ 43��6_   $	��100��6o   $��Center=�6{   $	��Top=�6�   ���	#000000006�   �� 59      -   5        $	 rctRightSlow��59      $	��184��6.   $	 530��6;   ���	#00000000$ 38��6`   $	��100��6p   ���	#00000000$
��Left=�6�   $��Center=�6�   6�   5:      �� 5;   
   -   5        $ cvsProcress��5;      $y�Hidden=�6&   .+�5<      � -   5         �Name$ pgrProgress��5<       ) %MahApps.Styles.Control.WindowCommands#��[ 6/   $��13��6n   $	 206��6z   $	 244��6�   $	��390��6�   
����p��$
��Left=�6�   $��Center=�6�    � Maximum$ 1Q�6�   �� 5=      -   5        $ lblTypeOfProcess��5=   2   #��[ 6   $��Label��6L   $	 214��6\   $	 127��6n   $
��Left=�6   $	��Top=�6�   $	��372��6�   $��Center=�6�   �� 5>      $	��100��6   "  WpfAnimatedGif.ImageBehavior   AnimatedSource$ /images/loading.gif��6!   $	 350��6X   $	 330��6j   $	��100��6{   5?      �� 5@   
   -   5        $ cvsDownload��5@      $y�Hidden=�6&   .+�5A      �� -   5         ��Name$ 	tbxSaveTo��5A       	 Input#��[ 6)   $ 80��6H    �� TextWrapping$
 Wrap=�6Y   $�� ��6m   $	 142��6u   $	��640��6�   $
��Left=�6�   $	��Top=�6�   6�   �� 5B      #��[ 6   $��Save To:��62   $ 80��6E   $ 98��6V   $��Center=�6f   $	��Top=�6�   �� 5C      -   5        $ btnOpen��5C      #��[  6&   $
��Open��6F   $	 725��6U   $	 142��6g   $��35��6x   $��76��6�   $��Center=�6�   $��Center=�6�   6�   �� 5D      -   5        $ 	tbxFolder��5D      #��[ 6)   $ 80��6H   $
 Wrap=�6Y   $�� ��6m   $	 244��6u   $	��320��6�   $
��Left=�6�   $��Center=�6�   6�   �� 5E      #��[ 6   $��Folder Name:��62   $ 80��6I   $	 200��6Z   $��Center=�6k   $	��Top=�6�   �� 5F      -   5        $ btnDownloadStart��5F      #��[  6/   $��Download��6O   $	 374��6b   $	 394��6t   $
��Left=�6�   $	��Top=�6�   $��37��6�   $	��121��6�   $y�Hidden=�6�   �� 5G      -   5        $ btnBack��5G      #��[  6&   $
��Back��6F   $ 10��6U   $ 10��6f   $��35��6v   $��75��6�   6�   5H      �� 5I   
   -   5        $ cvsEdit��5I      $y�Hidden=�6"   .+�5J      �� -   5        $ 	btnRemove��5J   5   #��[  6   $��Remove��6H   $	 382��6Y   $	 202��6k   $
��Left=�6|   $��Center=�6�   $��97��6�   6�   �� 5K      -   5        $ btnAdd��5K   5   #��[  6   $	��Add��6E   $	 382��6S   $	 166��6e   $��Center=�6v   $��Center=�6�   $��97��6�   6�   �� 5L      -   5        $ tbxTag��5L      #��[ 6&   $ 62��6E   $
 Wrap=�6V   $�� ��6j   $	 184��6r   $	��294��6�   $
��Left=�6�   $��Center=�6�   �� 5M      #��[ 6   $	��Tag��62   $ 62��6@   $	 140��6Q   $��Center=�6b   $	��Top=�6   �� 5N      -   5        $ 	btnUpdate��5N   5   #��[  6   $��Update��6H   $	 348��6Y   $	 428��6k   $��30��6|   $	��105��6�   $
��Left=�6�   $	��Top=�6�   6�   �� 5O      -   5        $ btnBacktoMain��5O      #��[  6,   $
��Back��6L   $ 10��6[   $ 10��6l   $
��Left=�6|   $��Center=�6�   $��74��6�   6�   �� 5P      -   5        $ spnlTags��5P      $	��494��6+   $	��242��68   $	 520��6D   $ 10��6V   $��Center=�6f   $	��Top=�6�   ���	#0CFFFFFF �� CanVerticallyScroll . 6�   5Q      5S      5T      