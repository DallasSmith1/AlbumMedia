   M S B A M L   `   `   `  ���� E  AAlbumMedia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:AlbumMedia
AlbumMedia  "    AlbumMedia.FileInteractivity   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     *localclr-namespace:AlbumMedia     U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com    N� Title$  FileInteractivity��$	��514��$	��801��.��� .+��� -    ��Name$ cvsMain��$y�Visible=�.+��� -    ��Name$ 	btnCancel�� 
  Modern#��[  $��Cancel��$
��Left=�$��	10,10,0,0q�$	��Top=�$��35��$��80���� -    ��Name$ lblFilesSelected��  Form#��[ $��Files Selected: 0��$
��Left=�$	��Top=� �� Left$	 318��
 �� Top$	 205���� -   $ btnShare��  ModernLargeShared#��[ $��Share��$ 83��$	 286��$
��Left=�$	��Top=��� -   $ btnDownload��  ModernLargeDownload#��[ $	 343��$	 286��$
��Left=�$	��Top=��� -   $ btnHide��  ModernLargeHide#��[ $	 213��$	 286��$
��Left=�$	��Top=��� -   $ btnEdit��  ModernLargeTags#��[ $	 473��$	 286��$
��Left=�$	��Top=��� -   $ 	btnDelete��  ModernLargeDelete#��[ $	 603��$	 286��$
��Left=�$	��Top=��� -	    ��Name$ svrFiles��$	��150��$	��780��$ 10��$ 55��$��Center=�$	��Top=�$��Disabled=�$��Hidden=�.���� -
    ��Name$ 	spnlFiles�� �� Orientation$ 
Horizontal=�$��Disabled=�$��Disabled=��� -   	 ��Name$	 rctLeft��$	��162��$ -3��$ 54��$	��177��$
��Left=�$��Center=�
 J� RenderTransformOrigin$
 0.5,0.5&�z�V� .~��� �� ��  �� Angle$
 -270Q�T� ����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#00000000��� $ 	#FF131313�� � Offset$ 0.677Q��� -   $	 rctRight��$	��162��$	 625��$ 47��$	��177��$
 0.5,0.5&�$
��Left=�$	��Top=�z�V� .~��� �� �� $	 -90Q�T� ���� $ 0.5,1&�$ 0.5,0&�.��� $ 	#00000000��$
 0.11Q�� $ 	#FF131313��$ 0.807Q��� -   $	 rctLeftSlow��$	��184��$	 170�����	#00000000$ 43��$	��100��$��Center=�$	��Top=����	#00000000�� -   $	 rctRightSlow��$	��184��$	 530�����	#00000000$ 38��$	��100�����	#00000000$
��Left=�$��Center=��� -   $ cvsProcress��$y�Hidden=�.+�� -    �Name$ pgrProgress�� ) %MahApps.Styles.Control.WindowCommands#��[ $��13��$	 206��$	 244��$	��390��
����p��$
��Left=�$��Center=� � Maximum$ 1Q��� -   $ lblTypeOfProcess��#��[ $��Label��$	 214��$	 127��$
��Left=�$	��Top=�$	��372��$��Center=��� $	��100��"  WpfAnimatedGif.ImageBehavior   AnimatedSource$ /images/loading.gif��$	 350��$	 330��$	��100���� -   $ cvsDownload��$y�Hidden=�.+��� -    ��Name$ 	tbxSaveTo�� 	 Input#��[ $ 80�� �� TextWrapping$
 Wrap=�$�� ��$	 142��$	��640��$
��Left=�$	��Top=��� #��[ $��Save To:��$ 80��$ 98��$��Center=�$	��Top=��� -   $ btnOpen��#��[  $
��Open��$	 725��$	 142��$��35��$��76��$��Center=�$��Center=��� -   $ 	tbxFolder��#��[ $ 80��$
 Wrap=�$�� ��$	 244��$	��320��$
��Left=�$��Center=��� #��[ $��Folder Name:��$ 80��$	 200��$��Center=�$	��Top=��� -   $ btnDownloadStart��#��[  $��Download��$	 374��$	 394��$
��Left=�$	��Top=�$��37��$	��121��$y�Hidden=��� -   $ btnBack��#��[  $
��Back��$ 10��$ 10��$��35��$��75���� -   $ cvsEdit��$y�Hidden=�.+��� -   $ 	btnRemove��#��[  $��Remove��$	 382��$	 202��$
��Left=�$��Center=�$��97���� -   $ btnAdd��#��[  $	��Add��$	 382��$	 166��$��Center=�$��Center=�$��97���� -   $ tbxTag��#��[ $ 62��$
 Wrap=�$�� ��$	 184��$	��294��$
��Left=�$��Center=��� #��[ $	��Tag��$ 62��$	 140��$��Center=�$	��Top=��� -   $ 	btnUpdate��#��[  $��Update��$	 348��$	 428��$��30��$	��105��$
��Left=�$	��Top=��� -   $ btnBacktoMain��#��[  $
��Back��$ 10��$ 10��$
��Left=�$��Center=�$��74���� -   $ spnlTags��$	��494��$	��242��$	 520��$ 10��$��Center=�$	��Top=����	#0CFFFFFF �� CanVerticallyScroll . 