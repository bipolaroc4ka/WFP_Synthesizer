   M S B A M L   `   `   `  ����J  FWFP_Synthesizer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WFP_SynthesizerWFP_Synthesizer  5   	        WFP_Synthesizer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WFP_Synthesizer     5   	   -   5          � Title$  Synthesizer��5   	   $	��450��6   $	��800��6*   ���	#FFC7DC6C � 	Resources 5
       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius F�Name �� Stretch	 ��Name
 �� Triggers P� Property P� Value �� 
TargetName��%�  '��       �� 5   
   " ��6   .�5      ��  � �� �#3737376+   �� 5       � ��
 �����6+   �� 5       � ��$ 15(�6)   �� 5       �@J�SnapsToDevicePixels . 64   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ 4��6!   #��z��62   ._�5      � .+�5   "   F� $ PathIcon��6'   $��15��69   $��25��6D   $
 Fill=�6P   ���#4C87B3$
��Left=�6n   $��17,0,0,0q�6�   4�������<R���=�x�O���Tn5����<R6�   �� 5   "   $	 MyContentPresenter��63   #��z��6O   $��Center=�6s   $��Center=�6�   $��0,0,0,0q�6�   5      5      
 5      P� 5       �@J�IsMouseOver . . �5   "   ��  � �� �#E594006?   �� 5   "    � ��
 �����6?   �� 5   "   $ PathIcon��6)    � ��
 �   �6O   5       P� 5"       � �� . . �5#   "   ��  � ��
 � E��6?   �� 5$   "    � ��
 �����6?   5%      5'      5)      5*      5+      .��5.      � .+�5/   
   �� $��Bottom=�6   $��
0,0,-0.4,0q�6-   $��49��6A   $��Bottom=�6M   ���	#FFC7DC6C.@�50      �� -   5         ��Name$ 	labelMode��50      $��Mode: ��6'   $	��245��68   $
��Bold"�6D   $��Impact)�6V   $��20(�6j   51      �� 52   
   -   5         ��Name$ 	buttonSin��52      $	��SIN��6$   $
��Left=�63   $��	33,31,0,0q�6N   $	��Top=�6a   $	��150��6y   $��44��6�   �� 53   
   -   5        $ buttonSquare��53      $��Square��6'   $
��Left=�68   $��	33,99,0,0q�6S   $	��Top=�6f   $	��150��6~   $��44��6�   �� 54   
   -   5        $ 	buttonSaw��54      $��Sawtooth��6$   $
��Left=�67   $��
33,173,0,0q�6R   $	��Top=�6f   $	��150��6~   $��44��6�   6�   �� 55   
   -   5        $ buttonTriangle��55      $��Triangle��6)   $
��Left=�6<   $��
33,244,0,0q�6W   $	��Top=�6k   $	��150��6�   $��44��6�   6�   �� 56   
   -   5        $ buttonWhiteNoize��56      $��White noize��6+   $
��Left=�6A   $��
33,322,0,0q�6\   $	��Top=�6p   $	��150��6�   $��44��6�   6�   57      58      