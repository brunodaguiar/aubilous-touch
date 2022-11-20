import {
  NativeBaseProvider,
  extendTheme,
  Pressable,
  Icon,
  HStack,
} from 'native-base';
import { createNativeStackNavigator } from '@react-navigation/native-stack';
import { NavigationContainer } from '@react-navigation/native';
import { StyleSheet, Text, Platform } from 'react-native';
import Login from './src/login/Login';
import NewCommunication from './src/newCommunication/NewCommunication';
import Communications from './src/communications/Communications';
import { MaterialIcons } from '@expo/vector-icons';

const Stack = createNativeStackNavigator();

export default function App() {
  const theme = extendTheme({
    colors: {
      secondary: {
        50: '#ff8873',
        100: '#ff765e',
        200: '#ff6449',
        300: '#ff5234',
        400: '#ff401e',
        500: '#fb3816',
        600: '#f7310d',
        700: '#ec2e0c',
        800: '#dc2e0f',
        900: '#cd2e12',
      },
      primary: {
        50: '#00448d',
        100: '#0960ac',
        200: '#1271be',
        300: '#1c82d0',
        400: '#2490dd',
        500: '#449fe1',
        600: '#64b0e5',
        700: '#8fc6ed',
        800: '#badcf4',
        900: '#e3f1fa',
      },
    },
  });

  return (
    <NativeBaseProvider theme={theme}>
      <NavigationContainer>
        <Stack.Navigator
          screenOptions={{
            headerTitleAlign: 'left',
            animationDuration: 2,
          }}
        >
          <Stack.Screen
            name="Login"
            component={Login}
            options={{
              headerShown: false,
              title: 'Login',
            }}
          />
          <Stack.Screen
            name="Communications"
            component={Communications}
            options={({ navigation }) => ({
              headerBackVisible: false,
              headerBackButtonMenuEnabled: false,
              title: 'Comunicados',
              headerRight: () => (
                <HStack mr={Platform.OS === 'web' ? 10 : 0}>
                  <Pressable mr={5}>
                    <HStack alignItems={'center'}>
                      {Platform.OS === 'web' && (
                        <Text
                          justifyContent="center"
                          mr="5"
                          style={{ fontWeight: 500 }}
                        >
                          Insights
                        </Text>
                      )}
                      <Icon
                        size="xl"
                        color="secondary.100"
                        // color="#11241"
                        name={'insights'}
                        as={MaterialIcons}
                      />
                    </HStack>
                  </Pressable>
                  <Pressable
                    borderRadius={'xl'}
                    onPress={() => navigation.navigate('NewCommunication')}
                  >
                    <HStack alignItems={'center'}>
                      {Platform.OS === 'web' && (
                        <Text
                          justifyContent="center"
                          mr="5"
                          style={{ fontWeight: 500 }}
                        >
                          Novo Comunicado
                        </Text>
                      )}
                      <Icon
                        size="xl"
                        // size={PixelRatio.getPixelSizeForLayoutSize(3)}
                        color="secondary.200"
                        name={'post-add'}
                        as={MaterialIcons}
                      />
                    </HStack>
                  </Pressable>
                </HStack>
              ),
            })}
          />
          <Stack.Screen
            name="NewCommunication"
            component={NewCommunication}
            options={{
              title: 'Enviar Novo Comunicado',
            }}
          />
          {/* <Stack.Screen
            name="CommunicationSent"
            component={CommunicationSent}
            options={{
              title: 'Comunicação Enviada',
            }}
          /> */}
        </Stack.Navigator>
      </NavigationContainer>
    </NativeBaseProvider>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
});
