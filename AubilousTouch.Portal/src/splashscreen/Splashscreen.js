import React, { Component, useState } from 'react';

export default SplashScreen = () => {
  const wayLogo = require('./../../assets/icon.png');
  const [progressValue, setProgressValue] = useState(5);

  const increaseProgressBar = () => {
    setTimeout(function () {
      setProgressValue((previous) => {
        if (previous < 100) return previous + 3;
        else return 100;
      });
    }, 600);
  };

  useEffect(() => {
    increaseProgressBar();
  });

  return (
    <Box flex={1} backgroundColor="white">
      <StatusBar
        animated={true}
        barStyle="dark-content"
        backgroundColor="white"
      />
      <Progress
        // bg="coolGray.100"
        _filledTrack={{
          bg: '#0D9D3E',
        }}
        value={progressValue}
      />
      <Center flex={1}>
        <Image
          source={wayLogo}
          mb={PixelRatio.getPixelSizeForLayoutSize(1)}
          maxHeight={PixelRatio.getPixelSizeForLayoutSize(90)}
          resizeMode="center"
          w={'4/5'}
          alt="Way Logo"
        />
        <HStack space={2} alignItems="center">
          <Spinner accessibilityLabel="Loading posts" color="#0D9D3E" />
          <Heading color="#0D9D3E" fontSize="md">
            Loading
          </Heading>
        </HStack>
      </Center>
    </Box>
  );
};
