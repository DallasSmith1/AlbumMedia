   M S B A M L   `   `   `  ����E  AAlbumMedia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:AlbumMedia
AlbumMedia  5   	       AlbumMedia.PasswordReset   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   $localclr-namespace:AlbumMedia  5   	   -   5          �Name$  wndPassword��5   	    � Title$ PasswordReset��5	   	   $	��295��6   $	��462��6,   ���	#FF131313 � WindowStartupLocation$ CenterScreen=�6O    � 
ResizeMode$ NoResize=�6t    � Icon$ /images/AMLogo.png��6�   .��5
      � .+�5   
   �� -   5         ��Name$ cvsEmail��5      $y�Visible=�6#   .+�5      �� -   5         ��Name$ tbxEmail��5       	  Input#��[  6(    �� Left$ 46��6G    �� TextWrapping$
 Wrap=�6X   $�� ��6l   
	 �� Top$		 140��6t   $	��370��6�   $��Center=�6�   $��Center=�6�   �� 5        MovieDescription#��[ 6   $��Email��6>   $ 46��6N   $		 110��6_   $��Center=�6p   $	��Top=�6�   �� 5        Form#��[ 6   $��Reset Password��62   $	 151��6K   $	 10��6]   $
��Left=�6m   $��Center=�6�   �� 5      -   5        
 ��Name$
 btnReset��5       
 Modern#��[ 6'   $��Reset��6G   $	 183��6W   $		 210��6i   $��Center=�6z   $	��Top=�6�   $��95��6�   6�   �� 5      #��[ 6   $%��Enter the email to your account��6>   $	 122��6h   $	 73��6z   �� 5      -   5         ��Name$ lblError��5      #��[ 6&   $�� ��6P   $ 62��6[   $		 180��6l   $
��Left=�6}   $��Center=�6�   5      �� 5   
   -   5        $ 
cvsLoading��5      $	��279��6%   $	��462��62   $y�Hidden=�6>   .+�5      �� $	��100��6   $	 181��6!   $	 90��63   $	��100��6C   "  WpfAnimatedGif.ImageBehavior   AnimatedSource$ /images/loading.gif��6O   5      �� 5   
   -   5        $ cvsSent��5      $	��279��6"   $	��462��6/   $y�Hidden=�6;   .+�5      �� #��[ 6   $2��,Check your mail for your temporary password.��6>   $ 70��6u   $		 110��6�   $
��Left=�6�   $	��Top=�6�   $	��322��6�   $��30��6�   �� 5      #��[ 6   $7��1It may take up to 5 minutes to recieve the email.��6>   $ 70��6z   $		 134��6�   �� 5      #��[ 6   $��
Email Sent��62   $	 175��6G   $	 10��6Y   �� 5      -   5        $
 btnClose��5   5   #��[ 6   $��Close��6G   $
��Left=�6W   $	��Top=�6r   $��34��6�   $��94��6�   $	 182��6�   $		 221��6�   6�   5      5      5      