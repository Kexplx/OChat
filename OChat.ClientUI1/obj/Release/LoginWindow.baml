   M S B A M L   `   `   `  ����   OChat.ClientUI1!    OChat.ClientUI1.LoginWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  -     � Title$  OChat - Join the fun�� � SizeToContent$ WidthAndHeight=� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ CanMinimize=� +� FocusedElement ��  �� ElementName$ TxtUsername��.��� $	��312��$	��151��.+��� $��	0,115,0,0q�
�������$��0,1,0,0q�._�� ���#F6F4F4$
��Left=�$��35��$��0q�$	��Top=�$	��312�� � ColumnDefinitions �� $	��86* ��� $
��227* �.+�"  FontAwesome.WPF.ImageAwesome  -   $��ImgBeginLogin�� � ToolTip$ Connect to Server��{�.     Icon$ SignIn=�$��	191,5,5,5q�	   
Foreground
	 ���F�
 J� Opacity$	
 0.6Q� � Cursor$
 Hand��$��1��  -   $��ImgBugReport��$��0��$	 Bug=�$��5,5,55,5q�
	 ���p�$ Report a Bug��$
 Hand�� J� RenderTransformOrigin$ 
0.345,0.48&�  $��0��$��	35,5,23,5q�$y�	Collapsed=�
	 �����$8 2New Version of OChat available, click to download!��$
 1Q�$
 Hand��$ 
0.345,0.48&�$ Download=�  -     Name$ SpinnerCog1��   Spin . $ Spinner=�$��
156,5,40,5q�
	 �iii�   SpinDuration$ 2Q�$y�	Collapsed=�$��1���� $��Host IPv4-Adress:��
���iii�$
��Left=�$��5,13,0,0q�$	��Top=�$	��105���� $��	Username:��
���iii�$
��Left=�$��5,75,0,0q�$	��Top=�$��92���� $��Port:��
���iii�$
��Left=�$��5,44,0,0q�$	��Top=�$��92���� -   $��BrdIpv4Adress��$��200,13,17,112q�$��0,0,0,1q�
�������._��� -   $��TxtIpv4Adress��$��Center=�
���iii�$��0q�$
��Left=� �� TextWrapping$
 Wrap=�$��	127.0.0.1��$	��Top=�$��0q�$��25��$��94���� -   $��BrdPort��$��200,44,17,81q�$��0,0,0,1q�
�������._��� -   $��TxtPort��$��Center=�
���iii�$��0q�$
��Left=�$
 Wrap=�$
��8931��$	��Top=�$��0q�$��25��$��94���� -	   $��BrdUsername��$��200,75,17,50q�$��0,0,0,1q�
�������._��� -
    ��Name$ TxtUsername�� �� 	MaxLength$ 10��|�. $��Center=�
���iii�$��0q�$
��Left=�$
 Wrap=�$	��Top=�$��0q�$��25��$��94��