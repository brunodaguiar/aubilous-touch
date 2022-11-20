import React, { useState } from 'react';
import { Input, Button, Image, Box } from 'native-base';
import {
  StyleSheet,
  Dimensions,
  ImageBackground,
  Alert,
  Platform,
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
    } else {
      if (Platform.OS === 'web') {
        alert('Dados incorretos. Por favor, tente novamente.');
      } else {
        Alert.alert('Atenção', 'Dados incorretos. Por favor, tente novamente.');
      }
    }
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
