   M S B A M L   `   `   `  ���� E  AAlbumMedia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:AlbumMedia
AlbumMedia      AlbumMedia.Movies   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com  $localclr-namespace:AlbumMedia    N� Title$  Movies��$
��1345��.���� $
��Auto=�$��Disabled=�$��0,0,0,0q�.��]� $��1����.  $
��auto��.+�� $
��1345��$
��5500��$	��Top=� � RowDefinitions �� $��1* ��� $��1* ��� $	��70* � � ColumnDefinitions �� $��50 ��� $	��40* ��� $��50 �.+��� -    ��Name$ lblCategory��   Form#��[  $��1��$	��All��$��Center=�$��0,0,0,0q�$��Center=��� $
��auto��$	��Top=�
������ $��Center=�$��0q�$��1��$��1��.@��� -    ��Name$ 	tbxSearch�� 
 Search#��[ $��0,0,0,0q� �� TextWrapping$
 Wrap=�$	��534���� -    ��Name$ 	btnSearch�� 
 Modern#��[ $��Search�� �� 	IsDefault . $��84��{�.  �� -    ��Name$ 
imgLoading��$��1��$��2��$��Center=�$	��136��$	��Top=�$	��148��	 �� Left$		 551��

 �� Top$
 10��"  WpfAnimatedGif.ImageBehavior   AnimatedSource$ /images/loading.gif��$y�Visible=��� -    ��Name$ cvsAll��$��1��$��2��$y�Hidden=�.+�� $
��1250�� �� $��1* ��� $	��325 ��� $��1* ��� $	��325 ��� $��1* ��� $	��325 ��� $��1* ��� $	��325 ��� $��1* ��� $	��325 ��� $��1* ��� $	��325 ��� $��1* ��� $	��325 ��� $��1* ��� $	��325 ��� $��1* ��� $	��325 ��� $��1* ��� $	��325 ��� $��1* ��� $	��325 ��� $��1* ��� $	��325 ��� $��1* ��� $	��325 ��� $��1* ��� $	��325 � �� $��1* ��� $	��20* ��� $��1* �.+��� -    ��Name$ svwKids��$��1��$��1��  ModernScrollView#��[ $��Hidden=�$��Disabled=�.���� -    ��Name$
 Kids��$
��Left=� �� Orientation$ 
Horizontal=��� -   $ svwAdult��$��3��$��1��#��[ $��Hidden=�$��Disabled=�.���� -	   $ Adult��$
��Left=�$ 
Horizontal=��� -
   $ 	svwHorror��$��5��$��1��#��[ $��Hidden=�$��Disabled=�.���� -   $ Horror��$
��Left=�$ 
Horizontal=��� -   $ 	svwDisney��$��7��$��1��#��[ $��Hidden=�$��Disabled=�.���� -   $ Disney��$
��Left=�$ 
Horizontal=��� -   $ 	svwComedy��$��9��$��1��#��[ $��Hidden=�$��Disabled=�.���� -   $ Comedy��$
��Left=�$ 
Horizontal=��� -   $ svwAnimated��$��11��$��1��#��[ $��Hidden=�$��Disabled=�.���� -   $ Animated��$
��Left=�$ 
Horizontal=��� -   $ svwScifi��$��13��$��1��#��[ $��Hidden=�$��Disabled=�.���� -   $ scifi��$
��Left=�$ 
Horizontal=��� -   $ 	svwAction��$��15��$��1��#��[ $��Hidden=�$��Disabled=�.���� -   $ Action��$
��Left=�$ 
Horizontal=��� -   $ svwAdventure��$��17��$��1��#��[ $��Hidden=�$��Disabled=�.���� -   $ 	Adventure��$
��Left=�$ 
Horizontal=��� -   $ svwSuperHero��$��19��$��1��#��[ $��Hidden=�$��Disabled=�.���� -   $ 	SuperHero��$
��Left=�$ 
Horizontal=��� -   $ svwStarWars��$��21��$��1��#��[ $��Hidden=�$��Disabled=�.���� -   $ StarWars��$
��Left=�$ 
Horizontal=��� -   $ svwJurassic��$��23��$��1��#��[ $��Hidden=�$��Disabled=�.���� -   $ Jurassic��$
��Left=�$ 
Horizontal=��� -   $ 
svwRomance��$��25��$��1��#��[ $��Hidden=�$��Disabled=�.���� -   $ Romance��$
��Left=�$ 
Horizontal=��� -    $ svwThriller��$��27��$��1��#��[ $��Hidden=�$��Disabled=�.���� -!   $ Thriller��$
��Left=�$ 
Horizontal=��� $��1��  
MovieTitle#��[ $
��Kids���� $��1��#��[ $��Adult��$��2���� $��1��#��[ $��Horror��$��4���� $��1��#��[ $��Disney��$��6���� $��1��#��[ $��Comedy��$��8���� $��1��#��[ $��Animated��$��10���� $��1��#��[ $��Sci-Fi��$��12���� $��1��#��[ $��Action��$��14���� $��1��#��[ $��	Adventure��$��16���� $��1��#��[ $��
Super Hero��$��18���� $��1��#��[ $��	Star Wars��$��20���� $��1��#��[ $��Jurassic��$��22���� $��1��#��[ $��Romance��$��24���� $��1��#��[ $��Thriller��$��26���� -"   $ btnKidsLeft��  NavigateLeft#��[ $��Right=�$��1��$��Center=�$��0,0,4,0q��� -#   $ btnKidsRight��  NavigateRight#��[ $��2��$��Right=�$��0,100,-23,0q�$��1��$	��Top=��� -$   $ btnAdultRight��$��2��#��[ $
��Left=�$��3��$	��Top=�$��
10,110,0,0q��� -%   $ btnAdultLeft��#��[ $��Center=�$��3��$��Center=��� -&   $ btnHorrorLeft��#��[ $��Center=�$��5��$��Center=��� -'   $ btnHorrorRight��$��2��#��[ $��Center=�$��5��$��Center=��� -(   $ btnDisneyLeft��#��[ $��Center=�$��7��$��Center=��� -)   $ btnDisneyRight��$��2��#��[ $��Center=�$��7��$��Center=��� -*   $ btnComedyLeft��#��[ $��Center=�$��9��$��Center=��� -+   $ btnComedyRight��$��2��#��[ $��Center=�$��9��$��Center=��� -,   $ btnAnimatedRight��$��2��#��[ $��Center=�$��11��$��Center=��� --   $ btnAnimatedLeft��#��[ $��Center=�$��11��$��Center=��� -.   $ btnScifiLeft��#��[ $��Center=�$��13��$��Center=��� -/   $ btnScifiRight��$��2��#��[ $��Center=�$��13��$��Center=��� -0   $ btnActionLeft��#��[ $��Center=�$��15��$��Center=��� -1   $ btnActionRight��$��2��#��[ $��Center=�$��15��$��Center=��� -2   $ btnAdventureLeft��#��[ $��Center=�$��17��$��Center=��� -3   $ btnAdventureRight��$��2��#��[ $��Center=�$��17��$��Center=��� -4   $ btnSuperHeroRight��$��2��#��[ $��Center=�$��19��$��Center=��� -5   $ btnSuperHeroLeft��#��[ $��Center=�$��19��$��Center=��� -6   $ btnStarWarsRight��$��2��#��[ $��Center=�$��21��$��Center=��� -7   $ btnStarWarsLeft��#��[ $��Center=�$��21��$��Center=��� -8   $ btnJurassicRight��$��2��#��[ $��Center=�$��23��$��Center=��� -9   $ btnJurassicLeft��#��[ $��Center=�$��23��$��Center=��� -:   $ btnRomanceRight��$��2��#��[ $��Center=�$��25��$��Center=��� -;   $ btnRomanceLeft��#��[ $��Center=�$��25��$��Center=��� -<   $ btnThrillerRight��$��2��#��[ $��Center=�$��27��$��Center=��� -=   $ btnThrillerLeft��#��[ $��Center=�$��27��$��Center=��� ->   $ 	cvsSearch��$��1��$��2��$y�Hidden=�.+�]� .+�� $	��Top=�$
��1250��$��Center=� �� $��1* ��� $	��200 ��� $	��200 ��� $	��200 ��� $	��200 ��� $	��200 ��� $��1* �.+��� -?   $
 pnl1��$��1��$	��200���� -@   $
 pnl2��$��2��$	��200���� -A   $
 pnl3��$��3��$	��200���� -B   $
 pnl4��$��4��$	��200���� -C   $
 pnl5��$��5��$	��200���� -D   $ cvsMovieDetails��$��3��$y�Hidden=�$��3��.+��� -E   $ btnClose�� 	 Close#��[ $	 10��$
 10���� -F   $ 	imgPoster��$	��418��$	��619��$	 90��$
 86����   MovieAttribute#��[ $��30(�$��Title:��$		 523��$
 83��$��56��$��92��$
��Left=�$��Center=��� -G   $ lblTitle��#��[ $��30(�$��Title��$		 603��$
 83��$��56��$	��674��$
��Left=�$��Center=��� #��[ $��30(�$��Release Year:��$		 523��$	
 139��$��56��$	��207��$
��Left=�$��Center=��� -H   $ lblReleaseYear��#��[ $��30(�$
��Year��$		 714��$	
 139��$��56��$	��281��$
��Left=�$��Center=��� #��[ $��30(�$��Company:��$		 523��$	
 203��$��56��$	��207��$
��Left=�$��Center=��� -I   $ 
lblCompany��#��[ $��30(�$��Company��$		 675��$	
 203��$��56��$	��602��$
��Left=�$��Center=��� #��[ $��30(�$��Description:��$		 523��$	
 324��$��56��$	��207��$��Center=�$	��Top=��� -J   $ btnPlay�� 	 Play#��[	 $		 584��$	
 499��$	��112��$��Center=�$	��Top=� J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� �� ��  �� Angle$ 91.055Q�T� �� -K   $ lblDescription�� 
 InfoBox#��� 
 $		 704��$
 Wrap=�$	
 330��$	��621��$	��275��$��30(�$��Center=�$	��Top=�$��Test Message��
������� �� 
IsReadOnly . ��Z� ��Z� �� #��[ $��30(�$��Genres:��$		 523��$	
 263��$��56��$	��207��$��Center=�$	��Top=��� -L   $ 	lblGenres��#��[ $��30(�$��Genres��$		 637��$	
 263��$��56��$	��698��$
��Left=�$��Center=��� -M   $ lblNoneFound�� 	 Title#��[ $��1��$��error��$
��Left=�$��
308,33,0,0q�$��2��$	��Top=�$y�Hidden=�