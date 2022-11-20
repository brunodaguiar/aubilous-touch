import React, { useState } from 'react';
import { Input, Button, Image, Box, Text } from 'native-base';
import {
  View,
  StyleSheet,
  PixelRatio,
  Dimensions,
  ImageBackground,
} from 'react-native';
import icon from './../../assets/aubilous_touch.png';
import background from './../../assets/background1.jpg';

const deviceHeight = Dimensions.get('window').height;

const Login = ({ navigation }) => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');

  const logIn = () => {
    if (username.length > 0 && password === '123456') {
      navigation.navigate('Communications');
    }
    // if (username === 'daniel.a.rocha@aubay.pt' && password === '123456') {
    //   navigation.navigate('NewMessage');
    // }
  };

  return (
    <>
      <Box width={'100%'} zIndex={10}>
        <ImageBackground
          resizeMode="cover"
          source={background}
          alt={'background'}
        >
          <Box height={deviceHeight * 0.4} justifyContent="flex-end">
            <Box
              style={{
                shadowColor: '#000',
                shadowOffset: {
                  width: 0,
                  height: 3,
                },
                shadowOpacity: 0.27,
                shadowRadius: 4.65,
                elevation: 6,
              }}
            >
              <Image
                alignSelf={'center'}
                source={icon}
                alt={'icon'}
                mb={-20}
                zIndex={100}
                size="xl"
              />
            </Box>
          </Box>
        </ImageBackground>
      </Box>
      <Box style={styles.container}>
        <Input
          color={'gray.600'}
          maxWidth={'95%'}
          mb={'3.5'}
          value={username}
          onChangeText={setUsername}
          placeholder={'Username'}
          style={styles.input}
        />
        <Input
          color={'gray.600'}
          maxWidth={'95%'}
          mb={'3.5'}
          value={password}
          onChangeText={setPassword}
          placeholder={'Password'}
          secureTextEntry={true}
          style={styles.input}
        />

        <Button
          minWidth={'200'}
          bgColor="primary.100"
          // bgColor="green"
          // color={'cyan.300'}
          // backgroundColor="secondary"
          // color={'primary'}
          // style={styles.input}
          onPress={logIn}
        >
          Login
        </Button>
      </Box>
    </>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
    backgroundColor: '#f4f4f4',
  },
  input: {
    width: 200,
    height: 44,
  },
});

export default Login;
