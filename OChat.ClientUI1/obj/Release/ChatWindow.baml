   M S B A M L   `   `   `  ����   OChat.ClientUI1     OChat.ClientUI1.ChatWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  -     � Title$  OChat - Join the Fun�� � SizeToContent$ WidthAndHeight=� � 
ResizeMode$ CanMinimize=� +� FocusedElement ��  �� ElementName$ TxtChatMessage�� � 	Resources  !  ListBoxtemStyleNoHighlighting �� 
TargetType �� Property �� Value	 �� 
TargetType
 ��Name��%`   &	        �� " ��.���  � �� �� "	 ��.R�� #��z��.+��� $
 contentPresenter��.��� $	��600��$	��500�����#F6F4F4.+��� 
�������
�������$��1,1,0,0q�$��75,0,0,0q�._��� -   $��RichTextBoxMainChatWindow��" �� VerticalScrollBarVisibility$
 Auto=�$
��Left=�$��0q� �� 
IsReadOnly . $	��Top=�$	��541��. �/� .T�J� �� -    ��Name$ ListBoxUsers��$��0��#��[  $��Stretch=�$��
0,0,425,39q�
�������$��0,1,0,1q�
����������� .R��� 
�������$��2,3,2,0q�$��0,0,0,1q�._�� $��0q�
������  � ColumnDefinitions �� $��15 ��� $��* �.+�"  FontAwesome.WPF.ImageAwesome  $��0��$��20��   Icon$ 
UserCircle=�   
Foreground �� *Color+�� $��12(�$��1��$
��Left=�
���iii����� *
FontWeight+���� *Name+�� $��98,559,22,20q�$��0,0,0,1q�
�������._��� -    ��Name$ TxtChatMessage��|�. 
���iii�$
��Left=�$��0q� �� TextWrapping$
 Wrap=� �� 	MaxLength$ 60��$��Center=�$	��Top=�$	��380��$��21��$��0q� J� RenderTransformOrigin$ 0.511,0.176&���  J� IsHitTestVisible .  $��12(�$��Enter your Message here��$��Center=�
�������$��100,561,171,20q�$	��229������ " ��.���  � y�$ 	Collapsed=� �� Triggers ��  �� Binding �� *Text+$ TxtChatMessage�� �� Value  .a���  � y�$ Visible=�  -   $��	ImgLogout�� � Cursor$
 Hand�� � ToolTip$ Logout��$ SignOut=�$��41,567,429,7q�$ 0.5,0.5&�
 ���F�z�V� .~��� �� ��  �� Angle$
 -180Q�T�   -     Name$ ImgBugReport��$
 Hand��$ Report a Bug��$	 Bug=�$��6,566,466,7q�$ 0.803,-0.355&�
 ���p�