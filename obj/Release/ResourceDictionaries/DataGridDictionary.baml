   M S B A M L   `   `   `  ���� R  NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� 
TargetType �� 
ResourceId �� TypeInTargetAssembly&    System.Windows.Controls.DataGrid �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels �Name	 J� Opacity
 � Points �� Stretch �� Triggers P� Property P� Value �� 
TargetName   	MovieList �� Padding ��Name � ColumnDefinitions � RowDefinitions    SelectAllCommand7  1System.Windows.Controls.DataGridHeadersVisibility
   All �� ConverterParameter!    HeadersVisibilityConverter �� 	Converter �� RelativeSource �� AncestorTypeG  ASystem.Windows.Controls.Primitives.DataGridColumnHeadersPresenter  Name   Column ��Name �� CanContentScroll ��Name  �� ScrollableHeight! � Maximum" �� Orientation# �� ViewportHeight$ �� ViewportSize*% �� #ComputedVerticalScrollBarVisibility& � Value' �� Mode( �� ScrollableWidth) �� ViewportWidth,* �� %ComputedHorizontalScrollBarVisibility+ �� Triggers, ]� 
Conditions- �� Property. �� Value�� F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml      %M  (��       $" DataGridSelectAllButtonStyle��"   )&	  �    �� "  ��.���  � �� �� " ��.R�� .+��� $ Border��
������  . � $ Arrow��
���   �$��Right=�$��8,8,3,3q�$
	 0.15Q�
 �   ��� ��� ��� ��� $ Uniform=�$��Bottom=� P�  �@J�IsMouseOver . . ��� $ Border��# � �� � ��P�  � �� . . ��� $ Border��# � �� � ��P�  � {� .  . ��� $ Arrow�� � y�$ 	Collapsed=��� "    .���  � ��
 ���� ��  � ��
 �   ���  � ��
 ���� ��  � ��$ 0q���   �@  RowDetailsVisibilityMode$ VisibleWhenSelected=���  � �� . ��  �@��PanningMode$
 Both=���  �@��IsFlicksEnabled .  ��  � �� �� "   .R��� 
������ #��z��#��z��# z�� . ._��� $ DG_ScrollViewer��|�.  ���� " ��.R��  �� $
��Auto ��� $��* ��� $
��Auto � �� $
��Auto ��� $��* ��� $
��Auto �.+��� #��Z |�.  ��C� *�� $" DataGridSelectAllButtonStyle��"   +y��� *HeadersVisibility+# Z # Z  �� "   ���� *CellsPanelHorizontalOffset+ �� "     $! PART_ColumnHeadersPresenter��$��1��y��� *HeadersVisibility+# Z # Z  �� "   �� $! PART_ScrollContentPresenter��# z��$��2��$��1���� $ PART_VerticalScrollBar��$��2��#! z  $" Vertical=�$��1��#$ z# #y�z% & �� *VerticalOffset+$' OneWay=� �� *TemplatedParent+� $��1��$��2�� �� ���� **(NonFrozenColumnsViewportHorizontalOffset+ �� "   �� $��* �.+��� $ PART_HorizontalScrollBar��$��1��#! z( $" 
Horizontal=�#$ z) #y�z* & �� *HorizontalOffset+$' OneWay=� �� *TemplatedParent+.���� # z + ]� , �� - �@��
IsGrouping. . �� "- �@%�IsVirtualizingWhenGrouping. .  ./���  � �� .  