import React, { Fragment, useState } from 'react';
import { Input, Button, Image, Box, Link } from 'native-base';
import {
  StyleSheet,
  Dimensions,
  ImageBackground,
  Alert,
  Platform,
} from 'react-native';
import { WebView } from 'react-native-webview';
import icon from './../../assets/aubilous_touch.png';
import background from './../../assets/background1.jpg';

const deviceHeight = Dimensions.get('window').height;

const SuccessReport = ({ navigation }) => {
  const uri =
    'https://app.powerbi.com/view?r=eyJrIjoiY2ZjMTY1Y2ItZjk5NC00NmY2LTk2NzEtN2M4ZGY3ZjQ3OGZmIiwidCI6IjFmMjNmYzc5LWEyNjktNDdmYS1iZDQzLTI1MjIyZTllNTc3NCIsImMiOjl9';

  return (
    <Fragment>
      {(Platform.OS === 'android' || Platform.OS === 'ios') && (
        <WebView
          source={{
            html: '<iframe title="aubiloustouch - Success Rate" width="100%" height="60%" src="https://app.powerbi.com/view?r=eyJrIjoiY2ZjMTY1Y2ItZjk5NC00NmY2LTk2NzEtN2M4ZGY3ZjQ3OGZmIiwidCI6IjFmMjNmYzc5LWEyNjktNDdmYS1iZDQzLTI1MjIyZTllNTc3NCIsImMiOjl9" frameborder="0" allowFullScreen="true"></iframe>',
          }}
        />
      )}
      {Platform.OS === 'web' && (
        <iframe
          title="aubiloustouch - Success Rate"
          width="100%"
          height="90%"
          src="https://app.powerbi.com/view?r=eyJrIjoiY2ZjMTY1Y2ItZjk5NC00NmY2LTk2NzEtN2M4ZGY3ZjQ3OGZmIiwidCI6IjFmMjNmYzc5LWEyNjktNDdmYS1iZDQzLTI1MjIyZTllNTc3NCIsImMiOjl9"
          frameborder="0"
          allowFullScreen="true"
        ></iframe>
      )}
      <Box bgColor="white" height={'10%'} width={'100%'}>
        <Link
          pr={10}
          justifyContent="flex-end"
          alignItems={'center'}
          width={'100%'}
          height="100%"
          onPress={() => navigation.navigate('Communications')}
        >
          Retornar à Lista de Comunicados
        </Link>
      </Box>
    </Fragment>
  );
};

export default SuccessReport;
